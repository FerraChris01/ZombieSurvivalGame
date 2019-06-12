using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun : weapon
{
    public Bullet bullet;
    public timer shootingTimer;
    public GameObject spawnPoint;
    public int shootingRate;
    public bool singleShot;
    public int ammoCapacity;

    private int ammo;

    private void Start()
    {
        reload();
    }

    public override void fire()
    {
        if (((singleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!singleShot && Input.GetKey(KeyCode.Mouse0))) && ammo > 0 && !shootingTimer.isTriggered())
        {
             Bullet nuovoPr = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
             shootingTimer.triggerTimer(shootingRate);
             ammo--;
            
        }
    }
    public void reload()
    {
        ammo = ammoCapacity;
    }

}
