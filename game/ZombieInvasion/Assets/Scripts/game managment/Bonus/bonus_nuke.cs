using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_nuke : bonus
{
    #region Singleton
    public static bonus_nuke instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public void run()
    {
        if (isSpawned)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ENEMY"))
            {
                int temp = g.transform.Find("enemy").GetComponent<enemy_entity>().getLifePoints();
                g.transform.Find("enemy").GetComponent<enemy_entity>().decLifePoints(temp);
            }
        }
    }
}
