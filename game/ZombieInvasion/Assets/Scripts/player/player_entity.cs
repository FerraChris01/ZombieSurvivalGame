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
    [SerializeField] int life;
    [SerializeField] int armor;
    private int score;

    private void Start()
    {
        score = 0;
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
    public void decLife(int l)
    {
        life -= l;
    }

    public int getArmor()
    {
        return armor;
    }
    public void decArmor(int a)
    {
        armor -= a;
    }    
}
