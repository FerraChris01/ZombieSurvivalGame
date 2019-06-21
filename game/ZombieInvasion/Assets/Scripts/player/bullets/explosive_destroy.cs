using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosive_destroy : MonoBehaviour
{
    [SerializeField] AudioSource explosionSound;
    void Start()
    {
        Destroy(gameObject, 1.5f);
        explosionSound.Play();
    }
}
