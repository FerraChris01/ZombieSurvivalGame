using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selected_weapon_updater : MonoBehaviour
{
    void Update()
    {
        if (player_equipment.instance.getSelectedWeaponKind() == 0)
            transform.GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getSelectedGun().name;
        else if (player_equipment.instance.getSelectedWeaponKind() == 2)
            transform.GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getSelectedBonus().name;
        else
            transform.GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getMelee().name;
    }
}
