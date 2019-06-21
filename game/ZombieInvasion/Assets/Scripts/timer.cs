using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeLeft;
    private int triggered; ///0 not triggered, 1 triggered timer is going, 2 timers has finished

    void Start()
    {
        timeLeft = 0;
        triggered = 0;
        resetTimer();
    }
    public void await(int towait)
    {
        triggered = 1;
        timeLeft = towait / 1000f;
        StartCoroutine("LoseTime");
    }

    IEnumerator LoseTime()
    {
        yield return new WaitForSeconds(timeLeft);
        triggered = 2;
        StopCoroutine("LoseTime");
    }

    public int triggerValue()
    {
        return triggered;
    }
    public void resetTimer()
    {
        triggered = 0;
    }
    public void destroyTimer()
    {
        Destroy(gameObject);
    }
}
