using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun_default : weapon_gun
{
    [SerializeField] int reloadingTime;
    [SerializeField] int reserveAmmo;
    [SerializeField] int magazineCapacity;
    [SerializeField] AudioClip emptyGunShot;
    private int reserve;
    private bool reloading;
    private int ammoInMag;

    public int Reserve { get => reserve; set => reserve = value; }
    public bool Reloading { get => reloading; set => reloading = value; }
    public int AmmoInMag { get => ammoInMag; set => ammoInMag = value; }
    public int ReloadingTime { get => reloadingTime; set => reloadingTime = value; }
    public int ReserveAmmo { get => reserveAmmo; set => reserveAmmo = value; }
    public int MagazineCapacity { get => magazineCapacity; set => magazineCapacity = value; }
    public AudioClip EmptyGunShot { get => emptyGunShot; set => emptyGunShot = value; }

    private void Start()
    {
        Clock = Instantiate(TimerPrefab).GetComponent<Timer>();
        reserve = reserveAmmo;
        reload();
    }
    public bool isReloading()
    {
        return reloading;
    }
    public void setReserveAmmo(int tot)
    {
        reserveAmmo = tot;
    }
    public int getReserve()
    {
        return reserve;
    }
    public int getAmmoInMagazine()
    {
        return ammoInMag;
    }
    public override void fire()
    {
        if (((SingleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!SingleShot && Input.GetKey(KeyCode.Mouse0))) && ammoInMag > 0 &&
            (Clock.triggerValue() == 0 || Clock.triggerValue() == 2) && !reloading)
        {
            GameObject firing = Instantiate(ShootingFire, SpawnPoint.transform.position, SpawnPoint.transform.rotation * Quaternion.Euler(0, 180, 0));
            firing.transform.SetParent(transform);
            Sound.PlayOneShot(ShootingSound);
            instantiateBullet();            
            Clock.await(ShootingRate);
            ammoInMag--;
        }
        else if (((SingleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!SingleShot && Input.GetKey(KeyCode.Mouse0))) && ammoInMag == 0 &&
            (Clock.triggerValue() == 0 || Clock.triggerValue() == 2) && !reloading)
        {
            Sound.PlayOneShot(emptyGunShot);
            Clock.await(ShootingRate);
        }

    }
    public virtual void instantiateBullet()
    {
    }
    public void reload()
    {
        if (!reloading && ammoInMag < magazineCapacity && reserve > 0)
        {
            reloading = true;
            Clock.resetTimer();
        }
    }
    public void resetReserve()
    {
        reserve = reserveAmmo;
    }
    public void abortReloading()
    {
        if (reloading)
        {
            reloading = false;
            Clock.resetTimer();
        }
    }
}
