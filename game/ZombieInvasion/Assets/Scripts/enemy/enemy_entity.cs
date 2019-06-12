using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_entity : MonoBehaviour
{
    public int lifePoints { get; set; }

    void Start()
    {
        lifePoints = 100;        
    }

    void Update()
    {
        if (lifePoints <= 0)
            Destroy(this.gameObject); //da sostituire con l'animazione die 

        Debug.Log(lifePoints);
    }
}
