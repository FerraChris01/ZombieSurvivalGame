using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed;
    private int damage;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemy_entity>().lifePoints -= damage;
            Destroy(this.gameObject);
        }
    }
    public void setDamage(int weaponDamage)
    {
        damage = weaponDamage;
    }

}
