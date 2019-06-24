using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_controller : MonoBehaviour
{
    [SerializeField] GameObject timerPrefab;
    private Timer time;
    [SerializeField] float lookRadius = 10f;
    private Transform target;
    private NavMeshAgent agent;
    private float speed;
    private Vector3 aVelocity;

    void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
        target = GameObject.FindGameObjectWithTag("player").transform;
        aVelocity = agent.velocity;
    }

    void Update()
    {
        if (!GetComponent<enemy_entity>().isDead)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {

                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    AttackTarget();
                }
                else
                   time.resetTimer();
               

            }
        }
        
    }
    
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void AttackTarget()
    {
        if (time.triggerValue() == 0)
            time.await(1000);        
        else if (time.triggerValue() == 2)
        {
            if (player_entity.instance.getArmor() > 0)
                player_entity.instance.decArmor(Game_manager.instance.getZombieDamage());
            else
                player_entity.instance.decLife(Game_manager.instance.getZombieDamage());

            time.await(Game_manager.instance.getZombieAttackingRate());
        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    
}
