using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTanks : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public bool attackState;

    public GameObject mount;
    public GameObject firingPosition;
    
    public Rigidbody bullet;
    public float power = 1500f;
    public float moveSpeed = 2f;
    public bool firingLimit;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("PlayerTank").transform;
        agent = GetComponent<NavMeshAgent>();
        firingLimit = false;
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();        
        
    }

    void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);
        

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
        
        attackState = false;
    }
    
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomX);
        if (Physics.Raycast(walkPoint, - transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }       
    }


    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        agent.SetDestination(transform.position + walkPoint);
        mount.transform.LookAt(player.transform.position);
        if(!alreadyAttacked)
        {
            if(firingLimit == false)
            {
                Rigidbody instance = Instantiate(bullet, firingPosition.transform.position, firingPosition.transform.rotation);
                Vector3 fwd = firingPosition.transform.TransformDirection(Vector3.forward);
                instance.AddForce(fwd * power);
            }
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
