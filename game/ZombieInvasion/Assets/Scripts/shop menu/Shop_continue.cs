using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_continue : MonoBehaviour
{
    [SerializeField] Button continueButton;

    private void Start()
    {
        continueButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Shop_menu_manager.instance.hideMenu();
    }
}
