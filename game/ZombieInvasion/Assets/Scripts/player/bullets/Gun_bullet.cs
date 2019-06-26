using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_bullet : Bullet
{
    private Vector3 weaponPosition;
    private float penetration;

    public float Penetration { get => penetration; set => penetration = value; }

    private void Start()
    {
        Destroy(gameObject, 2);
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        int temp = 0;
        if (other.gameObject.tag == "enemy")
        {
            float offset = Vector3.Distance(weaponPosition, other.gameObject.transform.position);
            temp = other.gameObject.GetComponent<enemy_entity>().getLifePoints() - (Damage - (int)(offset * FadingK));
            other.gameObject.GetComponent<enemy_entity>().decLifePoints(Damage - (int)(offset * FadingK));
            Damage -= (int)(Damage * penetration);
            Debug.Log(temp);
        }
        else
            Destroy(gameObject);

        if (Damage <= 0 || temp > 0)
            Destroy(gameObject);        
        
    }
    public void setDamage(int weaponDamage, Vector3 weaponPosition, float fk)
    {
        this.weaponPosition = weaponPosition;
        FadingK = fk;
        Damage = weaponDamage;
    }


}
