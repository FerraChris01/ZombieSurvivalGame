using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletSpeed;

    private int damage;
    private float fadingK;

    public int Damage { get => damage; set => damage = value; }
    public float FadingK { get => fadingK; set => fadingK = value; }
    public int BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }
}
