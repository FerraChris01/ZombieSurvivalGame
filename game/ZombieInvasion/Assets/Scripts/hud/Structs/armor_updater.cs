using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor_updater : MonoBehaviour
{
    void Update()
    {
       GetComponent<SimpleHealthBar>().UpdateBar(player_entity.instance.Armour, player_entity.instance.MaxArmour);
    }
}
