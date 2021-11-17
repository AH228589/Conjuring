
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    //Set in inspector
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool hasAttacked;
    public GameObject projectile;
    public Transform firePoint;

    //States
    public float sightRange, attackRange;
    public bool inSightRange, inAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //If the player is not in sight or attack range - patrol random locations
        if (!inSightRange && !inAttackRange)
            Patrol();
        //If the player is in sight range, but not in attack range - chase the player
        if (inSightRange && !inAttackRange)
            Chase();
        //if the player is in sight and attack range - stop and shoot
        if (inSightRange && inAttackRange)
            Attack();
    }

    private void Patrol()
    {
        if (!walkPointSet)
        {
            //If the walkpoint is not set, search for one
            SearchWalkPoint();
        }
        else
        {
            //If the walkpoint is set, move the agent towards it's position
            agent.SetDestination(walkPoint);
        }

        //If the agent has moved to the random patrol position, unset it so it can be set again
        Vector3 walkDistance = transform.position - walkPoint;
        if (walkDistance.magnitude < 0.2f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        //Get a random x and z coordinate based on walkpointrange
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Checking to see if the new walkpoint coordinates are on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        //This just sets the target destination to that of the player
        agent.SetDestination(player.position);
    }
    private void Attack()
    {
        //This stops the agent from approaching any further and faces the player
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        //If it hasn't attacked yet - attack
        if (!hasAttacked)
        {
            hasAttacked = true;

            //Instantiate a projectile and give it forward and upward impulse
            Rigidbody rb = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);

            //Reset the attack after timeBetweenAttacks has passed
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }
}
