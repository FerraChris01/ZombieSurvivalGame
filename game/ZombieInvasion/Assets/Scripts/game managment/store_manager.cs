using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store_manager : MonoBehaviour
{
    public void buyRifle()
    {
        weapon_gun rifle = player_equipment.instance.getGuns()[2];
        if (player_entity.instance.getMoney() >= rifle.getPrice())
        {
            if (!rifle.IsBought())
                rifle.setBought();
        }
            //player_equipment.instance.getShootingEquipment()[2] = gunList[2];
    }
    public void buyShotgun()
    {
        //if (player_entity.instance.getMoney() >= gunList[1].getPrice())
            //player_equipment.instance.getShootingEquipment()[1] = gunList[1];
    }
    public void buyPistol()
    {

    }
}
