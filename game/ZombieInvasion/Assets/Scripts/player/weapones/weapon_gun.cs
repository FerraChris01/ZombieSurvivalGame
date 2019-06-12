using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun : weapon
{
    [SerializeField] Bullet bullet;
    [SerializeField] timer shootingTimer;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int shootingRate;
    [SerializeField] bool singleShot;
    [SerializeField] int reserveAmmo;
    [SerializeField] int magazineCapacity;
    private int ammo;

    public void setReserveAmmo(int tot)
    {
        reserveAmmo = tot;
    }
    public int getReserveAmmo()
    {
        return reserveAmmo;
    }
    public int getAmmoInMagazine()
    {
        return ammo;
    }

    private void Start()
    {
        reload();
    }

    public override void fire()
    {
        if (((singleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!singleShot && Input.GetKey(KeyCode.Mouse0))) && ammo > 0 && !shootingTimer.isTriggered())
        {
             Bullet nuovoPr = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
             nuovoPr.setDamage(damage);
             shootingTimer.triggerTimer(shootingRate);
             ammo--;            
        }
    }
    public void reload()
    {
        ammo = magazineCapacity;
        reserveAmmo -=  magazineCapacity - ammo;
    }

}
