using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_points_manager : MonoBehaviour
{

    [SerializeField] GameObject[] vect;
    [SerializeField] timer time;
    [SerializeField] GameObject zombie;
    private int zombiesToSpawn;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        zombiesToSpawn = Game_manager.instance.getZombiesNumber();
    }

    void Update()
    {
        if ((time.triggeredValue() == 0 || time.triggeredValue() == 2) && zombiesToSpawn > 0)
        {
            time.triggerTimer(Game_manager.instance.getZombieSpawningTimeRate());
            int temp = Random.Range(0, 3);
            Instantiate(zombie, new Vector3(vect[temp].transform.position.x, player.transform.position.y , vect[temp].transform.position.z), zombie.transform.rotation);
            zombiesToSpawn--;          
        }
        

    }
}
