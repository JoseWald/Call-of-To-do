using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator _enemyAnim;
    private NavMeshAgent _navMeshAgent;
    private EnemyState _enemyState;

    public float walkSpeed=0.5f;
    public float runSpeed=4f;
    public float chaseDistance=7f;

    private float _currentChaseDist;

    public float attackDist=1.8f;

    public float chaseAfterAttackDist=2f;

    public float patrolRadiusMIN=20f , patrolRadiusMAX=60f;

    public float patrofForThisTime=50f;

    private float _patrolTimer;

    public float waitBeforAttack=2f;

    private float _attackTimer;

    private Transform _target;

    public GameObject attackPoint;

    void Awake(){
        _enemyAnim=GetComponent<EnemyAnimator>();
        _navMeshAgent=GetComponent<NavMeshAgent>();

        _target=GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        _enemyState=EnemyState.PATROL;
        _patrolTimer=patrofForThisTime;
        _attackTimer=waitBeforAttack;
        _currentChaseDist=chaseDistance;
    }

    // Update is called once per frame
    void Update()
    {
         if(_enemyState==EnemyState.PATROL){
             Patrol();
         }

         if(_enemyState==EnemyState.CHASE){
             Chase();
         }

         if(_enemyState==EnemyState.ATTACK){
             Attack();
         }
    }//Update()

    void Patrol(){
        _navMeshAgent.isStopped=false;
        _navMeshAgent.speed=walkSpeed;

        _patrolTimer +=Time.deltaTime;

        if(_patrolTimer > patrofForThisTime){
            SetNewRandomDestination();
            _patrolTimer=0f;
        }

        if(_navMeshAgent.velocity.sqrMagnitude>0){
            _enemyAnim.Walk(true);
        }else{
            _enemyAnim.Walk(false);
        }

        if(Vector3.Distance(transform.position , _target.position)<=chaseDistance){
            _enemyAnim.Walk(false);
            _enemyState=EnemyState.CHASE;

            //play spotted audio
        }
    }//Patrol()

    void Chase(){
         _navMeshAgent.isStopped=false;
         _navMeshAgent.speed=runSpeed;

         _navMeshAgent.SetDestination(_target.position);

           if(_navMeshAgent.velocity.sqrMagnitude>0){
            _enemyAnim.Run(true);
        }else{
            _enemyAnim.Run(false);
        }

         if(Vector3.Distance(transform.position , _target.position)<=attackDist){
             _enemyAnim.Run(false);
             _enemyAnim.Walk(false);
             _enemyState=EnemyState.ATTACK;

             if(chaseDistance != _currentChaseDist){
                 chaseDistance=_currentChaseDist;
             }
         }else if(Vector3.Distance(transform.position , _target.position)>chaseDistance){
             _enemyAnim.Run(false);
             _enemyState=EnemyState.PATROL;

             _patrolTimer =patrofForThisTime;

            if(chaseDistance != _currentChaseDist){
                 chaseDistance=_currentChaseDist;
            }
         }

    }//Chase()

    void Attack(){
        _navMeshAgent.velocity = Vector3.zero;
        _navMeshAgent.isStopped=true;

        _attackTimer+=Time.deltaTime;

        if(_attackTimer > waitBeforAttack){
            _enemyAnim.Attack();
            OnAnimationDamage();
            _attackTimer=0f;

            //play attack sound
        }

        if(Vector3.Distance(transform.position , _target.position)> attackDist +chaseAfterAttackDist){
            _enemyState=EnemyState.CHASE;
        }
    }

    void SetNewRandomDestination(){
        float randRadius=Random.Range(patrolRadiusMIN,patrolRadiusMAX);

        Vector3 randDir = Random.insideUnitSphere * randRadius ;
        randDir+=transform.position;

        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randDir , out navMeshHit , randRadius , -1);

        _navMeshAgent.SetDestination(navMeshHit.position);
    }

    public void OnAnimationDamage(){

    }

    void TurnOnAttackPoint(){
        attackPoint.SetActive(true);
    }

     void TurnOffAttackPoint(){
         if(attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }

    public EnemyState EnemyState{
        get{
            return _enemyState;
        }set{
            _enemyState=value;
        }
        //can be shortcutted as :
        //get ; set ; 

    }
}
