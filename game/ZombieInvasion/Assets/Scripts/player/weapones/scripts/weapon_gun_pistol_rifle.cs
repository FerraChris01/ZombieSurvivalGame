using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun_pistol_rifle : weapon_gun_default
{
    [SerializeField] AudioClip reloadingSound;
    public override void instantiateBullet()
    {
        Gun_bullet nBullet = (Gun_bullet)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        nBullet.setDamage(getDamage(), transform.position, getFadingCoefficient());
    }
    void Update()
    {
        if (Reloading)
        {
            if (Clock.triggerValue() == 0)
            {
                Sound.PlayOneShot(reloadingSound);
                Clock.await(ReloadingTime);
            }
            else if (Clock.triggerValue() == 2)
            {
                if (Reserve >= MagazineCapacity)
                {
                    Reserve -= MagazineCapacity - AmmoInMag;
                    AmmoInMag = MagazineCapacity;
                }
                else
                {
                    AmmoInMag = Reserve;
                    Reserve = 0;
                }
                Clock.resetTimer();
                Reloading = false;
            }

        }
    }
}
