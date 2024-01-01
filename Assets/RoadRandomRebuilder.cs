using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadRandomRebuilder : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] [Min(0.0f)] private float minTime = 0.0f;
    [SerializeField] [Min(0.0f)] private float maxTime = 1.0f;
    [SerializeField] [Range(0, 10_000)] private int epsilon = 10_000;

    [Header("Events")]
    [SerializeField] private List<UnityEvent> events = new List<UnityEvent>();
    [SerializeField] private UnityEvent necessarily = new UnityEvent();

    System.Random random = new System.Random();
    private float time;

    private void Awake()
    {
        if (maxTime < minTime)
        {
            maxTime = minTime + 1.0f;
        }

        ResetTimer();
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            Do();
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        int from = (int)(minTime * epsilon);
        int to = (int)(maxTime * epsilon);

        time = random.Next(from, to) / epsilon;
    }

    private void Do()
    {
        int index = random.Next(events.Count);

        necessarily.Invoke();
        events[index].Invoke();
    }
}
