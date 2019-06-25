using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_wheel_manager : MonoBehaviour
{
    [SerializeField] GameObject wheel;
    void Update()
    {
        if (!Game_manager.instance.IsPaused && player_equipment.instance.getSelectedWeaponKind() != 2)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
                wheel.gameObject.SetActive(true);
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                int s = GetComponent<RMF_RadialMenu>().getSelectedIndex() - 1;
                if (s != -1)
                    player_equipment.instance.switchGun(s, false);

                wheel.gameObject.SetActive(false);
            }
        }

    }
}
