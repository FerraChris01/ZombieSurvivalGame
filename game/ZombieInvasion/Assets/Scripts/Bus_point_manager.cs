using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus_point_manager : MonoBehaviour
{
    #region Singleton
    public static Bus_point_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private bool busPointReached;

    public bool BusPointReached { get => busPointReached; set => busPointReached = value; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player" && Game_manager.instance.RoundIsOver)
            busPointReached = true;

    }
    public void resetBusPoint()
    {
        busPointReached = false;
    }
}
