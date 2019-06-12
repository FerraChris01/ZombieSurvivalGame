using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_equipment : MonoBehaviour
{
    #region Singleton
    public static player_equipment instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] weapon_gun gun;
    [SerializeField] weapon_melee melee;

    private bool currentWeapon;

    public bool getCurrentWeapon()
    {
        return currentWeapon;
    }

    public weapon_gun getGun()
    {
        return gun;
    }

    public weapon_melee getMelee()
    {
        return melee;
    }

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
