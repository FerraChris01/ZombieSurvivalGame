using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour
{
    #region Singleton
    public static Game_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    [SerializeField] int zombieLife;
    [SerializeField] int zombiesNumber;
    [SerializeField] int zombieDamage;
    [SerializeField] int zombieAttackingRate;
    [SerializeField] int playerLife;
    [SerializeField] int playerArmour;
    [SerializeField] int zombieSpawningTimeRate;
    [SerializeField] store_manager store;
    private int zombiesLeft;
    private int round;

    private void Start()
    {
        round = 1;
        zombiesLeft = zombiesNumber;
    }
    public int getZombiesLeft()
    {
        return zombiesLeft;
    }
    public void decZombiesLeft()
    {
        zombiesLeft--;
    }
    public int getCurrentRound()
    {
        return round;
    }
    public void incRound()
    {
        round++;
    }
    public int getZombieSpawningTimeRate()
    {
        return zombieSpawningTimeRate;
    }
    public int getPlayerLife()
    {
        return playerLife;
    }
    public int getPlayerArmour()
    {
        return playerArmour;
    }
    public int getZombieAttackingRate()
    {
        return zombieAttackingRate;
    }
    public int getZombieLife()
    {
        return zombieLife;

    }
    public int getZombiesNumber()
    {
        return zombiesNumber;
    }
    public int getZombieDamage()
    {
        return zombieDamage;
    } //
   
}
