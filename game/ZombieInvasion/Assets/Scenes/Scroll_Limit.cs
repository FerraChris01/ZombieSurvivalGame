using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll_Limit : MonoBehaviour
{
    public float Min_PositionY;
    public float Max_PositionY;
    private float a = 0;

    private RectTransform scroll;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.ForceUpdateCanvases();
    }

    // Update is called once per frame
    void Update()
    {
        scroll = GetComponent<RectTransform>();
        if (scroll.localPosition.y < Min_PositionY && Input.mouseScrollDelta.y > 0)
        {
           // Debug.Log("OK");
        }

    }
}