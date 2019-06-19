using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun : weapon
{
    [SerializeField] Gun_bullet bullet;
    [SerializeField] Grenade grenade;
    [SerializeField] timer time;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int shootingRate;
    [SerializeField] bool singleShot;
    [SerializeField] int reserveAmmo;
    [SerializeField] int magazineCapacity;
    [SerializeField] int reloadingTime;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioClip reloadingSound;
    [SerializeField] AudioClip bulletInsertingSound;
    [SerializeField] AudioClip emptyGunShot;
    [SerializeField] bool noMag;
    [SerializeField] bool isBought;
    [SerializeField] int isBonus;   //0 for normal gun, 1 for minigun, 2 for grenade launcher
    //[SerializeField] Sprite indicator;
    private bool reloading;
    private int ammoInMag;
    private int reserve;
    
    public bool IsBought()
    {
        return isBought;
    }
    public void setBought()
    {
        isBought = true;
    }
    public bool isReloading()
    {
        return reloading;
    }
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
        return ammoInMag;
    }
    private void Start()
    {
        if (isBonus == 1)
            setDamage(Game_manager.instance.getZombieLife() / 2);
        else if (isBonus == 2)
        {
            Ray ray = Camera.main.ScreenPointToRay(transform.position);
        }

        if (isBonus == 1 || isBonus == 2)
            ammoInMag = 1;
        else
        {
            reserve = reserveAmmo;
            reload();
        }
    }
    public override void fire()
    {
        if (((singleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!singleShot && Input.GetKey(KeyCode.Mouse0))) && ammoInMag > 0 &&
            (time.triggeredValue() == 0 || time.triggeredValue() == 2) && !reloading)
        {
            sound.PlayOneShot(shootingSound);
            if (isBonus == 2)
            {
                Grenade nGranade = Instantiate(grenade, spawnPoint.transform.position, spawnPoint.transform.rotation);
                time.triggerTimer(shootingRate);
            }
            else
            {                
                Gun_bullet nBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
                nBullet.setDamage(getDamage(), transform.position, getFadingCoefficient());
                time.triggerTimer(shootingRate);
                if (isBonus == 0)
                    ammoInMag--;
            }
        }
        else if (((singleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!singleShot && Input.GetKey(KeyCode.Mouse0))) && ammoInMag == 0 &&
            (time.triggeredValue() == 0 || time.triggeredValue() == 2) && !reloading)
        {
            sound.PlayOneShot(emptyGunShot);
            time.triggerTimer(shootingRate);
        }

    }
    public void reload()
    {
        if (!reloading && ammoInMag < magazineCapacity)
        {
            reloading = true;
            time.resetTimer();
        }

    }
    public void resetReserve()
    {
        reserve = reserveAmmo;
    }

    private void Update()
    {
        if (noMag && reloading)
        {
            
            if (time.triggeredValue() == 0 || time.triggeredValue() == 2)
            {
                sound.PlayOneShot(bulletInsertingSound);
                ammoInMag++;
                reserve--;
                time.triggerTimer(reloadingTime);
            }
            if (ammoInMag == magazineCapacity)
            {
                reloading = false;
                time.resetTimer();
            }

        }
        else if (!noMag && reloading)
        {
            if (time.triggeredValue() == 0)
            {
                sound.PlayOneShot(reloadingSound);
                time.triggerTimer(reloadingTime);
            }
            else if (time.triggeredValue() == 2)
            {
                reserve -= magazineCapacity - ammoInMag;
                ammoInMag = magazineCapacity;
                time.resetTimer();
                reloading = false;
            }

        }
    }
    public void abortReloading()
    {
        if (reloading)
        {
            reloading = false;
            time.resetTimer();
        }
    }
}
