using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombies_left_updater : MonoBehaviour
{
    private void Update()
    {
        transform.GetComponent<UnityEngine.UI.Text>().text = "Zombies remaining: " + Game_manager.instance.getZombiesLeft().ToString();
    }
    
}
