using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_menu_manager : MonoBehaviour
{
    #region Singleton
    public static Shop_menu_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] GameObject gameHUD;
    private bool waiting;

    private void Start()
    {
        waiting = false;
    }

    public void Awaken()
    {
        showMenu();
        AwakenComponents();
    }

    private void showMenu()
    {
        Cursor.visible = true;
        transform.Find("Main Panel").gameObject.SetActive(true);
        gameHUD.SetActive(false);
        AwakenComponents();
    }
    public void hideMenu()
    {
        Cursor.visible = false;
        transform.Find("Main Panel").gameObject.SetActive(false);
        gameHUD.SetActive(true);
        Game_manager.instance.startNewRound();
    }
    private void AwakenComponents()
    {
        Shop_money_updater.instance.Awaken();
        Shop_health_armour_updater.instance.Awaken();

    }
}
