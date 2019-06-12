using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    private int timeLeft;
    public bool triggered;

    void Start()
    {
        triggered = false;
    }
    public void triggerTimer(int towait)
    {
        triggered = true;
        timeLeft = towait / 1000;
        StartCoroutine("LoseTime");
    }

    IEnumerator LoseTime()
    {
        yield return new WaitForSeconds(timeLeft);
        triggered = false;
        StopCoroutine("LoseTime");
    }

    public bool isTriggered()
    {
        return triggered;
    }
}
