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

    [SerializeField] weapon_gun_default[] guns;
    [SerializeField] weapon_gun_bonus[] bonusGuns;
    [SerializeField] weapon_melee melee;
    private int selectedGun;
    private int weaponKind;
    private int temp;


    public int getSelectedWeaponKind()
    {
        return weaponKind;
    }
    void Start()
    {             
        switchGun(0, false);
    }
    public weapon_gun_default[] getGuns()
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
    public weapon_gun_default getSelectedGun()
    {
        return guns[selectedGun];
    }    
    public weapon_gun_bonus getSelectedBonus()
    {
        return bonusGuns[selectedGun - 3];
    }
    public int getSelectedGunIndex()
    {
        return selectedGun;
    }
    public void attack()
    {
        if (weaponKind == 0)
            guns[selectedGun].fire();
        else if (weaponKind == 2)
            bonusGuns[selectedGun - 3].fire();
        else
            melee.fire();
    }
    public void switchGun(int index, bool fromBonus)
    {        
        if (fromBonus)
        {
            weaponKind = 0;
            foreach (weapon_gun_bonus gun in bonusGuns)
              gun.gameObject.SetActive(false);

            selectedGun = temp;
        }
        guns[selectedGun].abortReloading();
        selectedGun = index;
        player_movement_controller.instance.resetSpeed();
        player_movement_controller.instance.PlayerSpeed *= guns[selectedGun].Weight;         
        for (int i = 0; i < 3; i++)
        {
            if (i != index)
                guns[i].gameObject.SetActive(false);
            else
                guns[i].gameObject.SetActive(true);
        }
        if (guns[selectedGun].getAmmoInMagazine() == 0)
            reload();

    }
    public void switchToBonus(int index)    //3 and 4
    {
        weaponKind = 2;
        temp = selectedGun;
        selectedGun = index;
        foreach (weapon_gun_default gun in guns)
            gun.gameObject.SetActive(false);

         bonusGuns[index - 3].gameObject.SetActive(true);
        player_movement_controller.instance.resetSpeed();
        player_movement_controller.instance.PlayerSpeed *= bonusGuns[index - 3].Weight;
    }
    public void reload()
    {
        if (weaponKind == 0)
            guns[selectedGun].reload();
        else
            melee.reload();
    }
}
