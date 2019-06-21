using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] Bonus_manager bonusManager;
    [SerializeField] dataStorage data;
    private int zombiesKilled;
    private int zombiesLeft;
    private int round;

    private void Start()
    {
        zombiesKilled = 0;
        round = 1;
        zombiesLeft = zombiesNumber;
    }
    public int getZombiesLeft()
    {
        return zombiesLeft;
    }
    public void endGame()
    {
        //data.time = time_updater.instance.clock.toString();
        data.rounds = round;
        data.zombiesKilled = zombiesKilled;
        SceneManager.LoadScene("endMenu");

    }
    public void decZombiesLeft(Vector3 zombiePos)
    {
        zombiesLeft--;
        zombiesKilled++;
        bonusManager.tryToSpawn(zombiePos);
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
