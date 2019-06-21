using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_controller : MonoBehaviour
{
    [SerializeField] Animation anim;

    [SerializeField] GameObject timerPrefab;
    [SerializeField] int duration;

    [SerializeField] int bonusID;

    private Timer time;

    public bool triggered { get; set; }
    public bool ending { get; set; }
    

    private void Start()
    {
        time = Instantiate(timerPrefab).GetComponent<Timer>();
        ending = false;        
    }
    public void Update()
    {
        if (!triggered)
        {
            if (!ending)
            {
                if (time.triggerValue() == 0)
                {
                    time.await(duration - (duration / 3));
                    anim.Play("expand");
                }
                if (time.triggerValue() == 2)
                {
                    anim.Play("blink");
                    time.resetTimer();
                    ending = true;
                }
            }
            else
            {
                if (time.triggerValue() == 0)
                    time.await(duration / 3);

                if (time.triggerValue() == 2)
                    Destroy(transform.parent.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player" && !triggered)
        {
            triggered = true;
            if (bonusID == 0)
                bonus_full_ammo.instance.run();
            else if (bonusID == 1)
                bonus_minigun.instance.run();
            else if (bonusID == 2)
                bonus_grenade_launcher.instance.run();

            Debug.Log("bonus active");
            Destroy(transform.parent.gameObject);
        }

    }    
}
