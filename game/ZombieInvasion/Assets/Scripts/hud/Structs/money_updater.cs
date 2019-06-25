using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money_updater : MonoBehaviour
{
    private UnityEngine.UI.Text txt;
    void Start()
    {
        txt = transform.GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        txt.text = player_entity.instance.Money.ToString() + " $";
    }
}
