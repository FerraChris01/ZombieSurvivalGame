using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_gun : weapon
{
    [SerializeField] GameObject timerPrefab;
    private Timer clock;

    [SerializeField] GameObject shootingFire;
    [SerializeField] Bullet bullet;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int shootingRate;
    [SerializeField] bool singleShot;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] bool isBought;

    public Bullet Bullet { get => bullet; set => bullet = value; }
    public GameObject SpawnPoint { get => spawnPoint; set => spawnPoint = value; }
    public int ShootingRate { get => shootingRate; set => shootingRate = value; }
    public bool SingleShot { get => singleShot; set => singleShot = value; }
    public AudioSource Sound { get => sound; set => sound = value; }
    public AudioClip ShootingSound { get => shootingSound; set => shootingSound = value; }
    public bool IsBought { get => isBought; set => isBought = value; }
    public GameObject TimerPrefab { get => timerPrefab; set => timerPrefab = value; }
    public Timer Clock { get => clock; set => clock = value; }
    public GameObject ShootingFire { get => shootingFire; set => shootingFire = value; }
}
