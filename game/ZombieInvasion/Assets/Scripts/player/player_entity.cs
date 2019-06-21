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

    private void Start()
    {
        score = 0;
        life = Game_manager.instance.getPlayerLife();
        armour = Game_manager.instance.getPlayerArmour();
        maxLife = life;
        maxArmour = armour;
    }
    public int getMoney()
    {
        return money;
    }
    public void incMoney(int m)
    {
        money += m;
    }
    public int getMaxLife()
    {
        return maxLife;
    }
    public void incScore(int s)
    {
        score += s;
    }
    public int getScore()
    {
        return score;
    }
    public int getLife()
    {
        return life;
    }
    public void decLife(int lf)
    {
        life -= lf;
        if (life <= 0)
            Game_manager.instance.endGame();

    }
    public int getArmor()
    {
        return armour;
    }
    public int getMaxArmour()
    {
        return maxArmour;
    }
    public void decArmor(int a)
    {
        armour -= a;
    }    
}
