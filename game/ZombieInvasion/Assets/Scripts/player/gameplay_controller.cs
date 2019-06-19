using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay_controller : MonoBehaviour
{  
    public player_equipment equipment;    

    void Update()
    {
        reload();
        fire();
        switchWeapon();
    }
    private void reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
            equipment.reload();            
        
    }
    private void fire()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
            equipment.attack();
        
    }
    private void switchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            equipment.switchGun(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            equipment.switchGun(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            equipment.switchGun(2);
    }
}
