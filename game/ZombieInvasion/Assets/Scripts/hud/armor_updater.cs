using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor_updater : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = player_entity.instance.getArmor().ToString();
    }
}
