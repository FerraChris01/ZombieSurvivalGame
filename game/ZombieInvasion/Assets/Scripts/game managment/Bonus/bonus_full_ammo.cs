using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_full_ammo : bonus
{
    public override void tryToSpawn()
    {
        base.tryToSpawn();
        if (isSpawned)
        {
            foreach (weapon_gun gun in player_equipment.instance.getGuns())
                gun.resetReserve();
        }
    }
}
