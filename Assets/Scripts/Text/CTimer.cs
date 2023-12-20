using UnityEngine;
using UnityEngine.UI;

public class CTimer : CPrefInteger
{
    Text text = null;
    int time = 0;
    float timeInterval;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = ToTime(this.time);
        Load();
    }

    private void Update()
    {
        timeInterval -= Time.deltaTime;

        if (timeInterval <= 0)
        {
            timeInterval = 1;
            time++;
            text.text = ToTime(this.time);
            
            TrySave(time);
        }
    }

    public static string ToTime(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;

        string strMin = minutes > 9 ? "" : "0";
        strMin += minutes;

        string strSec = seconds > 9 ? "" : "0";
        strSec += seconds;

        return $"{strMin}:{strSec}";
    }
}
