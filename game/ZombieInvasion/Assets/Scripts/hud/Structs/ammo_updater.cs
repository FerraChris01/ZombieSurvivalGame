using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_updater : MonoBehaviour
{
    void Update()
    {
        transform.FindChild("MagazineAmmo").GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getSelectedGun().getAmmoInMagazine().ToString();
        transform.FindChild("ReserveValue").GetComponent<UnityEngine.UI.Text>().text = player_equipment.instance.getSelectedGun().getReserveAmmo().ToString();
    }
}
