using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_updater : MonoBehaviour
{
    #region Singleton
    public static time_updater instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private float timerFromStart;
    public CData clock { get; set; }

    private void Start()
    {
        
    }
    void Update()
    {
        timerFromStart += Time.deltaTime;
        int minutes = (int)Mathf.Floor(timerFromStart / 60);
        int seconds = (int)timerFromStart % 60;
        int hours = (int)timerFromStart / 3600;
        CData clock = new CData(seconds, minutes, hours);

        GetComponent<UnityEngine.UI.Text>().text = clock.toString();
    }
}
public class CData
{
    public int seconds { get; set; }
    public int minutes { get; set; }
    public int hours { get; set; }

    public CData()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;
    }
    public CData(int seconds, int minutes, int hours)
    {
        this.seconds = seconds;
        this.minutes = minutes;
        this.hours = hours;
    }
    public string toString()
    {
        return equalizedValue(hours, true) + equalizedValue(minutes, false) + ":" + equalizedValue(seconds, false);
    }
    public string equalizedValue(int val, bool isHour)
    {
        if (isHour)
            return (val > 0 ? (val < 10 ? "0" + val.ToString() : val.ToString()) + ":" : "");
        else
            return (val < 10 ? "0" + val.ToString() : val.ToString());
    }
}
  
