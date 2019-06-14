using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class round_updater : MonoBehaviour
{
    private void Update()
    {
        transform.GetComponent<UnityEngine.UI.Text>().text = "Round " + Game_manager.instance.getCurrentRound().ToString();
    }
}
