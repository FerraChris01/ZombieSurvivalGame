using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_points_manager : MonoBehaviour
{
    [SerializeField] GameObject timerPrefab;
    private Timer time;

    [SerializeField] GameObject[] vect;
    [SerializeField] GameObject zombie;

    private GameObject player;

    private void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if ((time.triggerValue() == 0 || time.triggerValue() == 2) && Game_manager.instance.getZombiesLeft() > 0)
        {
            time.await(Game_manager.instance.getZombieSpawningTimeRate());
            int temp = Random.Range(0, 3);
            Instantiate(zombie, new Vector3(vect[temp].transform.position.x, player.transform.position.y , vect[temp].transform.position.z), zombie.transform.rotation);       
        }
        

    }
}
