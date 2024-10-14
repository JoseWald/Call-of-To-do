using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//we gonna need it when the script is attached to the enemy
public class Health : MonoBehaviour
{
    private EnemyAnimator _enemyAnim;

    private NavMeshAgent _navAgent;

    private EnemyController _enemyController;

    public float health=100f;

    private bool _isDead=false;

    public bool isPlayer , isZombie;

    private EnemyAudio _enemyAudio;
 
    void Awake(){
        if(isZombie){
            _enemyAnim=GetComponent<EnemyAnimator>();
            _enemyController=GetComponent<EnemyController>();
            _navAgent=GetComponent<NavMeshAgent>();

            _enemyAudio = GetComponentInChildren<EnemyAudio>();
        }

        if(isPlayer){

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHurt(float damage){
        if(_isDead){
            return;
        }

        health-=damage;

        if(isPlayer){
            //Display the health UI value
        }

        if(isZombie){
            if(_enemyController.EnemyState == EnemyState.PATROL){
                //Debug.Log("Zombie Hitted");
                _enemyController.chaseDistance =100f;
            }
        }

        if(health<0){
            PlayerDie();
            _isDead=true;
        }
        Debug.Log("HP="+health);
    }//GetHurt()

    void PlayerDie(){
        if(isZombie){
            GetComponent<Animator>().enabled=false;
            GetComponent<BoxCollider>().isTrigger=false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f);

            _enemyController.enabled=false;
            _navAgent.enabled=false;
            _enemyAnim.enabled=false;

            StartCoroutine(DeadSound());

            //spawn more enemy
        }
        if(isPlayer){
            GameObject[] enemies=GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for(int i=0 ; i<enemies.Length ; i++){
                enemies[i].GetComponent<EnemyController>().enabled=false;
            }

            //the enemy should stop spawning

            GetComponent<PlayerMovement>().enabled=false;
            GetComponent<Attack>().enabled=false;
            GetComponent<WeaponManager>().GetSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag ==Tags.PLAYER_TAG){
            Invoke("RestartGame",3f);
        }else{
            Invoke("TurnOffGameObject",3f);
        }
    }//PlayerDie()

    void RestartGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    void TurnOffGameObject(){
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound(){
        yield return new WaitForSeconds(0.3f);
        _enemyAudio.PlayDeadSound();
    }
}
