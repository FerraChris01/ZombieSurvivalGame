using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    [SerializeField] float spawningProbability;
    [SerializeField] int timeToLive;
    protected bool isSpawned;  
    
    public virtual void tryToSpawn()
    {
        float k = Random.Range(0f, 100f);
        if (k == spawningProbability)
            isSpawned = true;

    }
    public float getSpawiningProbability()
    {
        return spawningProbability;
    }
    public void incSpawningProbability(float sp)
    {
        spawningProbability += sp;
    }
}
