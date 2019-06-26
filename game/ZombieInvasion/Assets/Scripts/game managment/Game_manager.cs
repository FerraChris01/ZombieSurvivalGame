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
    [SerializeField] bool isPaused;

    private int zombiesKilled;
    private int zombiesLeft;
    private int round;
    private bool roundIsOver;
    

    public bool IsPaused { get => isPaused; set => isPaused = value; }
    public bool RoundIsOver { get => roundIsOver; set => roundIsOver = value; }

    private void Start()
    {
        roundIsOver = false;
        zombiesKilled = 0;
        round = 1;
        zombiesLeft = zombiesNumber;
    }
    private void Update()
    {
        if (roundIsOver && Bus_point_manager.instance.BusPointReached)
        {
            isPaused = true;
            Shop_menu_manager.instance.Awaken();
        }    
        //startNewRound();
                
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
        if (zombiesLeft == 0)
            roundIsOver = true;
                    
    }
    public int getCurrentRound()
    {
        return round;
    }
    public void startNewRound()
    {
        isPaused = false;
        roundIsOver = false;
        Bus_point_manager.instance.resetBusPoint();             
        spawn_points_manager.instance.SpawnIsOver = false;
        zombiesLeft = zombiesNumber + (zombiesNumber / 3);
        zombieLife += zombieLife / 3;
        round++;
        spawn_points_manager.instance.resetZombiesToSpawn();
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
