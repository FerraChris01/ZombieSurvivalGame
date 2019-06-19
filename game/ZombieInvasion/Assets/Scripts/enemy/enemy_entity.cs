using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_entity : MonoBehaviour
{
    [SerializeField] timer time;
    [SerializeField] int timeBeforeDestroying;
    private int lifePoints;
    public bool isDead { get; set; }
    
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

    void Start()
    {
        Game_manager.instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_manager>();
        lifePoints = Game_manager.instance.getZombieLife();
        isDead = false;
    }

    void Update()
    {
        if (lifePoints <= 0)
        {
            if (time.triggeredValue() == 0)
            {
                isDead = true;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                Game_manager.instance.decZombiesLeft();
                player_entity.instance.incMoney(100);
                time.triggerTimer(timeBeforeDestroying);
            }
            else if (time.triggeredValue() == 2)
                Destroy(this.gameObject); //da sostituire con l'animazione die 
        }        
    }
}
