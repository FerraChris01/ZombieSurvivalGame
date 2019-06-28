using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_manager : MonoBehaviour
{
    #region Singleton
    public static Bonus_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] bonus[] bonuses;

    public void tryToSpawn(Vector3 zombiePos)
    {
        int temp = Random.Range(0, bonuses.Length);
        bonuses[temp].tryToSpawn(zombiePos);
    }
    public List<int> getSelectedIndex()
    {
        List<int> temp = new List<int>();
        foreach (bonus b in bonuses)
        {
            if (b.IsActive)
                temp.Add(b.BonusID);
        }
        return temp;
    }
}
