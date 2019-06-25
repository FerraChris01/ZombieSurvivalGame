using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_armour : MonoBehaviour
{
    private Button buyBtn;
    private int value;

    void Start()
    {
        buyBtn = transform.Find("Button").GetComponent<Button>();
        buyBtn.onClick.AddListener(TaskOnClick);
        Awaken();
    }
    public void Awaken()
    {
        value = 1000;
        transform.Find("Price").GetComponent<Text>().text = value + " $";
    }

    void TaskOnClick()
    {
        if (player_entity.instance.Money >= value && player_entity.instance.Armour < player_entity.instance.MaxArmour)
            fillArmour();

        Shop_money_updater.instance.updateMoney();
    }
    void fillArmour()
    {
        player_entity.instance.Money -= value;
        player_entity.instance.Armour = player_entity.instance.MaxArmour;
    }
}
