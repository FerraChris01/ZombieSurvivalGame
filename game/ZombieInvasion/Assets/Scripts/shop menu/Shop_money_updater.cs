using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_money_updater : MonoBehaviour
{
    public void Awaken()
    {
        GetComponent<UnityEngine.UI.Text>().text = player_entity.instance.getMoney().ToString() + " $";
    }
}
