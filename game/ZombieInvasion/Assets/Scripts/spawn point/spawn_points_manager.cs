using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_points_manager : MonoBehaviour
{

    [SerializeField] GameObject[] vect;
    [SerializeField] int zombieNumber;
    [SerializeField] timer time;
    [SerializeField] GameObject zombie;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    public int getZombieNumber()
    {
        return zombieNumber;
    }
    public void setZombieNumber(int n)
    {
        zombieNumber = n;
    }

    void Update()
    {
        if (!time.isTriggered() && zombieNumber > 0)
        {
            time.triggerTimer(2000);
            int temp = Random.Range(0, 3);
            Instantiate(zombie, new Vector3(vect[temp].transform.position.x, player.transform.position.y , vect[temp].transform.position.z), zombie.transform.rotation);
            zombieNumber--;
        }
        

    }
}
