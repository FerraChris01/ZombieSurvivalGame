using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_controller : MonoBehaviour
{
    [SerializeField] timer time;
    [SerializeField] float lookRadius = 10f;
    private Transform target;
    NavMeshAgent agent;
    private float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
        target = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                agent.speed = 0;

                FaceTarget();
                AttackTarget();
            }
            else
            { 
                agent.speed = speed;
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
        if (time.triggeredValue() == 0)
            time.triggerTimer(500);
        else if (time.triggeredValue() == 2)
        {
            if (player_entity.instance.getArmor() > 0)
                player_entity.instance.decArmor(Game_manager.instance.getZombieDamage());
            else
                player_entity.instance.decLife(Game_manager.instance.getZombieDamage());

            time.triggerTimer(Game_manager.instance.getZombieAttackingRate());
            
        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
