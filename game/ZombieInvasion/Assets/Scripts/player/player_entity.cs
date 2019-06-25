using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_entity : MonoBehaviour
{
    #region Singleton
    public static player_entity instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    private int life;
    private int armour;
    private int maxLife;
    private int maxArmour;
    private int score;
    private int money;

    public int Life { get => life; set => life = value; }
    public int Armour { get => armour; set => armour = value; }
    public int MaxLife { get => maxLife; set => maxLife = value; }
    public int MaxArmour { get => maxArmour; set => maxArmour = value; }
    public int Score { get => score; set => score = value; }
    public int Money { get => money; set => money = value; }

    private void Start()
    {
        score = 0;
        life = Game_manager.instance.getPlayerLife();
        armour = Game_manager.instance.getPlayerArmour();
        maxLife = life;
        maxArmour = armour;
    }
    public void incMoney(int m)
    {
        money += m;
    }
    public void incScore(int s)
    {
        score += s;
    }
    public void decLife(int lf)
    {
        life -= lf;
        if (life <= 0)
            Game_manager.instance.endGame();

    }
    public void decArmor(int a)
    {
        armour -= a;
    }    
}
