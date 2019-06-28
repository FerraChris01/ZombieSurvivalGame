using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_health_armour_updater : MonoBehaviour
{
    #region Singleton
    public static Shop_health_armour_updater instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public void Awaken()
    {
        updateHA();
    }
    public void updateHA()
    {
        GetComponent<UnityEngine.UI.Text>().text = "LIFE POINTS: " + player_entity.instance.Life + "/" + player_entity.instance.MaxLife
            + "\n" + "ARMOUR POINTS: " + player_entity.instance.Armour + "/" + player_entity.instance.MaxArmour;
    }
}
