using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_life_updater : MonoBehaviour
{
    [SerializeField] GameObject enemyGameObject;

    private enemy_entity enemy;
    private int maxZombieLife;
    private bool notMax;

    private void Start()
    {
        enemy = enemyGameObject.GetComponent<enemy_entity>();
        maxZombieLife = enemy.getLifePoints();
    }
    void Update()
    {
        if (!notMax)
        {
            if (enemy.getLifePoints() < maxZombieLife)
            {
                notMax = true;
                gameObject.GetComponent<Canvas>().enabled = true;
            }
        }
        else
        {
            transform.Find("fill").GetComponent<UnityEngine.UI.Image>().fillAmount = enemy.getLifePoints() / (float)maxZombieLife;
            if (enemy.GetComponent<enemy_entity>().getLifePoints() <= 0)
                Destroy(this.gameObject);
        }
    }
}
