using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun_bonus : weapon_gun
{ 
    [SerializeField] int bonus;

    private weapon_gun_default temp;
    private void Start()
    {
        Clock = Instantiate(TimerPrefab).GetComponent<Timer>();
        if (bonus == 1)
            setDamage(Game_manager.instance.getZombieLife() / 2);
        else if (bonus == 2)
            setDamage((int)(Game_manager.instance.getZombieLife() * 1.5f));
    }
    public override void fire()
    {
        if (((SingleShot && Input.GetKeyDown(KeyCode.Mouse0)) || (!SingleShot && Input.GetKey(KeyCode.Mouse0))) &&
            (Clock.triggerValue() == 0 || Clock.triggerValue() == 2))
        {
            Sound.PlayOneShot(ShootingSound);
            if (bonus == 2)
            {
                Grenade nGranade = (Grenade)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            }
            else
            {
                Gun_bullet nBullet = (Gun_bullet)Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                nBullet.setDamage(getDamage(), transform.position, getFadingCoefficient());
                Clock.await(ShootingRate);
            }
            Clock.await(ShootingRate);
        }
    }
}
