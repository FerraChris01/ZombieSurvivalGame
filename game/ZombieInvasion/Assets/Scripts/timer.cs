using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float timeLeft;
    [SerializeField] int triggered; ///0 not triggered, 1 triggered timer is going, 2 timers has finished

    void Start()
    {
        resetTimer();
    }
    public void triggerTimer(int towait)
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

    public int triggeredValue()
    {
        return triggered;
    }
    public void resetTimer()
    {
        triggered = 0;
    }
}
