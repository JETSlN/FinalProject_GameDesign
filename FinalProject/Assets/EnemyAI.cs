using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask groundMask, playerMask;

    public Actions enemyActions;

    public GameObject projectile;

    float attackCooldown;
    bool alreadyAttacked;

    [SerializeField]
    float sightRange, attackRange, bulletSpeed, maxHealth, health, deathAnim;
    [SerializeField]
    bool seePlayer, attackPlayer;

    void Start()
    {
        health = maxHealth;
    }

    void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        seePlayer = Physics.CheckSphere(transform.position, sightRange, playerMask);
        attackPlayer = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (attackPlayer) {
            enemyActions.Attack();
            AttackPlayer();
        } else if (seePlayer) {
            enemyActions.Run();
            ChasePlayer();
        } else {
            enemyActions.Stay();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
    
    void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke("ResetAttack", attackCooldown);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) {
            enemyActions.Death();
            Destroy(gameObject, deathAnim);
        } else {
            enemyActions.Damage();
        }
    }
}
