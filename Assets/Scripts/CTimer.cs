using UnityEngine;
using UnityEngine.UI;

public class CTimer : MonoBehaviour
{
    Text text = null;
    int time = 0;
    float timeInterval;

    private void Awake()
    {
        text = GetComponent<Text>();
        SetText();
    }

    private void Update()
    {
        timeInterval -= Time.deltaTime;

        if (timeInterval <= 0)
        {
            timeInterval = 1;
            time++;
            SetText();
        }
    }

    private void SetText()
    {
        int minutes = time / 60;
        int seconds = time % 60;

        string strMin = minutes > 9 ? "" : "0";
        strMin += minutes;

        string strSec = seconds > 9 ? "" : "0";
        strSec += seconds;

        text.text = $"{strMin}:{strSec}";
    }
}
