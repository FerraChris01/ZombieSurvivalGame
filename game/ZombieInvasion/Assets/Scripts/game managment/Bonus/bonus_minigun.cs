using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_minigun : bonus
{
    [SerializeField] int duration;
    [SerializeField] timer time;
    private bool minigunActive;
    private int temp;

    private void Start()
    {
        minigunActive = false;
        temp = 0;
    }
    public override void tryToSpawn()
    {
        base.tryToSpawn();
        if (isSpawned)
        {
            player_equipment.instance.switchGun(3);
            temp = player_equipment.instance.getSelectedGunIndex();
            minigunActive = true;
        }
    }
    private void Update()
    {
        if (minigunActive)
        {
            if (time.triggeredValue() == 0)
                time.triggerTimer(duration);

            if (time.triggeredValue() == 2)
            {
                player_equipment.instance.switchGun(temp);
                minigunActive = false;
            }
        }
    }
}
