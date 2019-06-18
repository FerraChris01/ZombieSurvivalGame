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

    [SerializeField] weapon_gun[] guns;
    [SerializeField] weapon_melee melee;
    private int selectedGun;    
    private bool weaponKind;

    void Start()
    {
        switchGun(0);       
        weaponKind = true;
    }
    public weapon_gun[] getGuns()
    {
        return guns;
    }
    public weapon_gun[] getShootingEquipment()
    {
        return guns;
    }
    public weapon_melee getMelee()
    {
        return melee;
    }
    public bool getKindOfWeapon()
    {        
        return weaponKind;
    }
    public weapon_gun getSelectedGun()
    {
        return guns[selectedGun];
    }    
    public int getSelectedGunIndex()
    {
        return selectedGun;
    }
    public void attack()
    {
        if (weaponKind)
            guns[selectedGun].fire();
        else
            melee.fire();
    }
    public void switchKindWeapon(bool sw)
    {
        weaponKind = sw;
    }
    public void switchGun(int index)
    {
        selectedGun = index;
        //for (int i = 0; i < 4; i++)
        //{
        //    if (i != index)
        //        guns[i].enabled = false;
       // }
    }
    public void reload()
    {
        if (weaponKind)
            guns[selectedGun].reload();
        else
            melee.reload();
    }
}
