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
    private int tempLifePoints;
    public bool isDead { get; set; }

    public int LifePoints { get => lifePoints; set => lifePoints = value; }

    void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        Game_manager.instance = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_manager>();
        isDead = false;
    }
    public int getLifePoints()
    {
        return lifePoints;
    }
    public void setLifePoints(int lp)
    {
        tempLifePoints = lifePoints;
        lifePoints = lp;
    }
    public void decLifePoints(int lp)
    {
        lifePoints -= lp;
    }    
    public void resetLifePointsFromBonus()
    {
        lifePoints = tempLifePoints;
    }

    void Update()
    {

        if (lifePoints <= 0)
        {
            if (time.triggerValue() == 0)
            {
                isDead = true;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                body.GetComponent<Rigidbody>().isKinematic = true;
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
