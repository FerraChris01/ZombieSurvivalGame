using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_instant_kill : bonus
{    
    [SerializeField] GameObject timerPrefab;
    private Timer clock; 


    #region Singleton
    public static bonus_instant_kill instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        clock = Instantiate(timerPrefab).GetComponent<Timer>();
    }
    public void run()
    {
        if (isSpawned)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ENEMY"))
                g.transform.Find("enemy").GetComponent<enemy_entity>().setLifePoints(1);

            bonus_updater.instance.ActiveBonus = 4;
            IsActive = true;
            clock.await(DurationTime);
        }
    }
    public void Update()
    {
        if (isSpawned && clock.triggerValue() == 2)
        {
            IsActive = false;
            isSpawned = false;
            bonus_updater.instance.resetSelectedBonus();
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ENEMY"))
                g.transform.Find("enemy").GetComponent<enemy_entity>().resetLifePointsFromBonus();
        }
    }
}
