using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletSpeed;

    private int damage;
    private float fadingK;
    
    public int BulletSpeed()
    {
        return bulletSpeed;
    }
    public int Damage()
    {
        return damage;
    }
    public float FadingK()
    {
        return fadingK;
    }
    public void setFadingK(float fk)
    {
        fadingK = fk;
    }
    public void setDamage(int dm)
    {
        damage = dm;
    }

}
