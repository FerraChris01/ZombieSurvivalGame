using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_weapon_updater : MonoBehaviour
{
    void Update()
    {
        if (player_equipment.instance.getCurrentWeapon())
            transform.GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getGun().name;
        else
            transform.GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getMelee().name;
    }
}
