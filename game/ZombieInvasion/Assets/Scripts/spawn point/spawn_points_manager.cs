using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_points_manager : MonoBehaviour
{
    #region Singleton
    public static spawn_points_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] GameObject timerPrefab;
    private Timer time;

    [SerializeField] GameObject[] vect;
    [SerializeField] GameObject zombie;

    private int zombiesToSpawn;
    private GameObject player;
    private bool spawnIsOver;

    public bool SpawnIsOver { get => spawnIsOver; set => spawnIsOver = value; }

    private void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        player = GameObject.FindGameObjectWithTag("player");
        resetZombiesToSpawn();
    }
    public void resetZombiesToSpawn()
    {
        zombiesToSpawn = Game_manager.instance.getZombiesLeft();
    }
    void Update()
    {
        if (!Game_manager.instance.IsPaused)
        {
            if ((time.triggerValue() == 0 || time.triggerValue() == 2) && zombiesToSpawn > 0)
            {
                time.await(Game_manager.instance.getZombieSpawningTimeRate());
                int temp = Random.Range(0, 3);
                Instantiate(zombie, new Vector3(vect[temp].transform.position.x, player.transform.position.y, vect[temp].transform.position.z), zombie.transform.rotation);
                zombiesToSpawn--;
            }
            if (zombiesToSpawn == 0)
                spawnIsOver = true;
        }

    }
}
