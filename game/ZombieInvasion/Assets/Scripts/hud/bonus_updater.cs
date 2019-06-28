using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonus_updater : MonoBehaviour
{
    #region Singleton
    public static bonus_updater instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] Sprite[] bonusSprites;
    private int activeBonus;

    private bool bonusActive;

    public int ActiveBonus { get => activeBonus; set => activeBonus = value; }

    void Start()
    {
        bonusActive = false;
        resetSelectedBonus();
    }

    void Update()
    {
        if (activeBonus != -1)
        {
            bonusActive = true;
            transform.Find("sprite").gameObject.SetActive(true);
            transform.Find("sprite").transform.Find("bonus").GetComponent<Image>().sprite = bonusSprites[Bonus_manager.instance.getSelectedIndex()[0]];
            // start animation
        }
        if (bonusActive && activeBonus == -1)
        {
            bonusActive = false;
            transform.Find("sprite").gameObject.SetActive(false);
        }
    }
    public void resetSelectedBonus()
    {
        activeBonus = -1;
    }
}
