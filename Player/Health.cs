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
 
    void Awake(){
        if(isZombie){
            _enemyAnim=GetComponent<EnemyAnimator>();
            _enemyController=GetComponent<EnemyController>();
            _navAgent=GetComponent<NavMeshAgent>();
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
            if(_enemyController.EnemyState = EnemyState.PATROL){
                _enemyController.chaseDistance = 50f;
            }
        }
    }
}
