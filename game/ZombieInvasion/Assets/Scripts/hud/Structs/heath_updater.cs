using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heath_updater : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = player_entity.instance.getLife().ToString();
    }
}
