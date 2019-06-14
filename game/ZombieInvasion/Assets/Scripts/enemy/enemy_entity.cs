using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_entity : MonoBehaviour
{
    private int lifePoints;

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
    }

    void Update()
    {
        if (lifePoints <= 0)
        {
            Game_manager.instance.decZombiesLeft();
            Destroy(this.gameObject); //da sostituire con l'animazione die 
        }        
    }
}
