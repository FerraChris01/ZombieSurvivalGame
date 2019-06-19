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

    public bool getSelectedWeaponKind()
    {
        return weaponKind;
    }
    void Start()
    {             
        weaponKind = true;
        switchGun(0);
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
    public void switchGun(int index)
    {
        guns[selectedGun].abortReloading();
        selectedGun = index;
        for (int i = 0; i < 5; i++)
        {
            if (i != index)
                guns[i].gameObject.SetActive(false);
            else
                guns[i].gameObject.SetActive(true);
        }
        if (guns[selectedGun].getAmmoInMagazine() == 0)
            reload();

    }
    public void reload()
    {
        if (weaponKind)
            guns[selectedGun].reload();
        else
            melee.reload();
    }
}
