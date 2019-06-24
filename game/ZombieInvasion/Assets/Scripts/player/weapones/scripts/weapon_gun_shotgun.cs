using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun_shotgun : weapon_gun_default
{
    [SerializeField] AudioClip bulletInsertingSound;

    void Update()
    {
        if (Reloading)
        {
            if (Reserve > 0)
            {
                if (Clock.triggerValue() == 0 || Clock.triggerValue() == 2)
                {
                    Sound.PlayOneShot(bulletInsertingSound);
                    AmmoInMag++;
                    Reserve--;
                    Clock.await(ReloadingTime);
                }
                if (AmmoInMag == MagazineCapacity || Reserve == 0)
                {
                    Reloading = false;
                    Clock.resetTimer();
                }
            }

        }
    }
    public override void instantiateBullet()
    {
        Gun_bullet fragmentS = (Gun_bullet)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        fragmentS.setDamage(getDamage() / 3, transform.position, getFadingCoefficient());

        Gun_bullet fragmentR = (Gun_bullet)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation *
            Quaternion.Euler(0, 10, 0));
        fragmentR.setDamage(getDamage() / 3, transform.position, getFadingCoefficient());

        Gun_bullet fragmentL = (Gun_bullet)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation *
            Quaternion.Euler(0, -10, 0));
        fragmentL.setDamage(getDamage() / 3, transform.position, getFadingCoefficient());
    }
}
