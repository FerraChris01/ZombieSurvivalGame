using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_grenade_launcher : bonus
{
    #region Singleton
    public static bonus_grenade_launcher instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] GameObject timerPrefab;
    private Timer time;
    private bool grenadeLauncher;
    private int temp;
    private void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        grenadeLauncher = false;
        isSpawned = false;
        temp = 0;
    }
    public void run()
    {
        if (isSpawned)
        {
            temp = player_equipment.instance.getSelectedGunIndex();
            player_equipment.instance.switchToBonus(4);            
            grenadeLauncher = true;
            IsActive = true;
            bonus_updater.instance.ActiveBonus = 2;
        }
    }
    private void Update()
    {
        if (grenadeLauncher)
        {
            if (time.triggerValue() == 0)
                time.await(DurationTime);
            else if (time.triggerValue() == 2)
            {
                player_equipment.instance.switchGun(temp, true);
                bonus_updater.instance.resetSelectedBonus();
                grenadeLauncher = false;
                isSpawned = false;
                IsActive = false;
            }
        }
    }
}
