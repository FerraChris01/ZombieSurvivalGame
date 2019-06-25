using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_money_updater : MonoBehaviour
{
    #region Singleton
    public static Shop_money_updater instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public void Awaken()
    {
        updateMoney();
    }
    public void updateMoney()
    {
        GetComponent<UnityEngine.UI.Text>().text = player_entity.instance.Money.ToString() + " $";
    }
}
