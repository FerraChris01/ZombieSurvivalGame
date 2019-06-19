using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_controller : MonoBehaviour
{
    [SerializeField] timer time;
    [SerializeField] timer fadingTimer;
    [SerializeField] int duration;
    private bool triggered;
    private bool fastFlashing;

    private int counter;
    private int bias;
    private bool blink;

    private void Start()
    {
        fadingTimer.triggerTimer(duration);
        triggered = false;
        fastFlashing = false;
        counter = 0;
        bias = 1000;
        time.resetTimer();
        blink = true;
    }
    private void Update()
    {
        if (!triggered)
        {
            if (time.triggeredValue() == 0)
            {
                time.triggerTimer(duration - 10000);
            }
            else if (time.triggeredValue() == 2 && !fastFlashing)
            {
                fastFlashing = true;
                time.triggerTimer(bias);
                GetComponent<SpriteRenderer>().enabled = false;
                counter += bias;
                bias -= bias / 10;
            }    

            if (fastFlashing)
                blinkSprite();
                
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" || !triggered)
        {
            triggered = true;
            Debug.Log("colliso");
            //time.triggerTimer(duration - 10000);
        }

    }
    private void blinkSprite()
    {
        if (fadingTimer.triggeredValue() == 1)
        {
            if (time.triggeredValue() == 2)
            {
                if (blink)
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                    blink = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    blink = true;
                }

                time.triggerTimer(bias);
                counter += bias;
                bias -= bias / 10;
            }
        }
        else
        {
            Debug.Log("sparito");
            Destroy(gameObject);
        }
    }
}
