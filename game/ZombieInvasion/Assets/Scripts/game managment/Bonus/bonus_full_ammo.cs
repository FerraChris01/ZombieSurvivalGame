using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_full_ammo : bonus
{
    #region Singleton
    public static bonus_full_ammo instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public void run()
    {
        foreach (weapon_gun_default gun in player_equipment.instance.getGuns())
            gun.resetReserve();

        isSpawned = false;
        Debug.Log("max ammo");
    }
}
