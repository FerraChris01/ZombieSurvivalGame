using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    [SerializeField] int spawningProbability;
    [SerializeField] GameObject bonusPrefab;
    [SerializeField] int bonusID;
    [SerializeField] int durationTime;

    protected bool isSpawned;
    private bool isActive = false;

    public int BonusID { get => bonusID; set => bonusID = value; }
    public int DurationTime { get => durationTime; set => durationTime = value; }
    public bool IsActive { get => isActive; set => isActive = value; }

    public virtual void tryToSpawn(Vector3 zombiePos)
    {
        if (!isSpawned)
        {
            float k = Random.Range(1, spawningProbability);
            if (k == 1)
            {
                Instantiate(bonusPrefab, zombiePos, Quaternion.identity);
                isSpawned = true;
            }
        }
    }
    public float getSpawiningProbability()
    {
        return spawningProbability;
    }
    public void incSpawningProbability(int sp)
    {
        spawningProbability -= sp;
    }
    public bool IsSpawned()
    {
        return isSpawned;
    }
}
