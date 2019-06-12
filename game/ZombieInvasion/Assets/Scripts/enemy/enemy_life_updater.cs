using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_life_updater : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Update()
    {
        GetComponent<UnityEngine.UI.Slider>().value = enemy.GetComponent<enemy_entity>().lifePoints / 100f;
        if (enemy.GetComponent<enemy_entity>().lifePoints <= 0)
            Destroy(this.gameObject);
    }
}
