using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_entity : MonoBehaviour
{
    [SerializeField] GameObject timerPrefab;
    private Timer time;
    [SerializeField] int timeBeforeDestroying;
    [SerializeField] Rigidbody body;
    private int lifePoints;
    public bool isDead { get; set; }

    void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        Game_manager.instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_manager>();
        lifePoints = Game_manager.instance.getZombieLife();
        isDead = false;
    }
    public int getLifePoints()
    {
        return lifePoints;
    }
    public void setLifePoints(int lp)
    {
        lifePoints = lp;
    }
    public void decLifePoints(int lp)
    {
        lifePoints -= lp;
    }    

    void Update()
    {
        if (lifePoints <= 0)
        {
            if (time.triggerValue() == 0)
            {
                isDead = true;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                body.isKinematic = true;
                Game_manager.instance.decZombiesLeft(transform.position);
                player_entity.instance.incMoney(100);
                Game_manager.instance.MoneyForRound += 100;
                time.await(timeBeforeDestroying);
            }
            else if (time.triggerValue() == 2)
            {
                time.destroyTimer();
                Destroy(transform.parent.gameObject); //da sostituire con l'animazione die                 
            }
        }        
    }
}
