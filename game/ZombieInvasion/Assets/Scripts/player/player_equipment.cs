using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_equipment : MonoBehaviour
{
    public weapon_gun gun;
    public weapon_melee melee;

    private bool currentWeapon;

    void Start()
    {
        currentWeapon = true;
    }

    public void attack()
    {
        if (currentWeapon)
            gun.fire();
        else
            melee.fire();
    }
    public void switchWeapon(bool sw)
    {
        currentWeapon = sw;
    }
    public void reload()
    {
        if (currentWeapon)
            gun.reload();
        else
            melee.reload();
    }
}
