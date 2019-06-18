using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_bullet : Bullet
{
    private Vector3 weaponPosition;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed(), ForceMode.VelocityChange);
    }
    private void Update()
    {
        if (Time().triggeredValue() == 0)
            Time().triggerTimer(2000);
        else if (Time().triggeredValue() == 2)
            Destroy(this.gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            float offset = Vector3.Distance(weaponPosition, other.gameObject.transform.position);
            other.gameObject.GetComponent<enemy_entity>().decLifePoints(Damage() - (int)(offset * FadingK()));
            Destroy(gameObject);
        }
    }
    public void setDamage(int weaponDamage, Vector3 weaponPosition, float fk)
    {
        this.weaponPosition = weaponPosition;
        setFadingK(fk);
        setDamage(weaponDamage);
    }

}
