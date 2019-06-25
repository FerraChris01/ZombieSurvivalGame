using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_health : MonoBehaviour
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
        value = 5000;
        transform.Find("Price").GetComponent<Text>().text = value + " $";
    }

    void TaskOnClick()
    {
        if (player_entity.instance.Money >= value && player_entity.instance.Life < player_entity.instance.MaxLife)
            fillLife();

        Shop_money_updater.instance.updateMoney();
    }
    void fillLife()
    {
        player_entity.instance.Money -= value;
        player_entity.instance.Life = player_entity.instance.MaxLife;
    }
}
