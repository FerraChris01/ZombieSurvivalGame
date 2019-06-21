using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_manager : MonoBehaviour
{
    [SerializeField] bonus[] bonuses;

    public void tryToSpawn(Vector3 zombiePos)
    {
        int temp = Random.Range(0, bonuses.Length);
        bonuses[temp].tryToSpawn(zombiePos);
    }
}
