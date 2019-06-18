using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_life_bar : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private Vector3 bias;
    void Start()
    {
        bias = transform.position - enemy.transform.position;
    }

    void Update()
    {
        transform.position = enemy.transform.position + bias;
        if (enemy.GetComponent<enemy_entity>().getLifePoints() <= 0)
            Destroy(this.gameObject);
    }
}
