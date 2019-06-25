using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_weapon_record : MonoBehaviour
{
    [SerializeField] Button showMore;
    [SerializeField] int index;
    private bool statsState;

    public int Index { get => index; set => index = value; }
    public Button ShowMore { get => showMore; set => showMore = value; }

    void Start()
    {
        showMore.onClick.AddListener(TaskOnClick);
        statsState = false;
    }
    void TaskOnClick()
    {
        if (!statsState)
        {
            Shop_weapon_manager.instance.showStatsOfRecord(index);
            statsState = true;
            showMore.transform.Find("Text").GetComponent<Text>().text = "-";
        }
        else
        {
            Shop_weapon_manager.instance.hideStatsOfRecord(index);
            statsState = false;
            showMore.transform.Find("Text").GetComponent<Text>().text = "+";
        }
    }
}
