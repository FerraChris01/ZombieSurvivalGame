using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heath_updater : MonoBehaviour
{
    void Update()
    {
        GetComponent<SimpleHealthBar>().UpdateBar(player_entity.instance.getLife(), player_entity.instance.getMaxLife());
    }
}
