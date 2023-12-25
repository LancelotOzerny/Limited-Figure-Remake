using UnityEngine;
using UnityEngine.Events;

public class CTimerBonuse : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float duration = 1.0f;
    private float startDuration;
    private bool isActive = false;

    [SerializeField] private UnityEvent beginEvent = null;
    [SerializeField] private UnityEvent endEvent = null;

    private void Start()
    {
        startDuration = duration;
    }

    public void Active()
    {
        isActive = true;
        duration = startDuration;

        if (beginEvent != null)
        {
            beginEvent.Invoke();
        }
    }

    private void Update()
    {
        if (isActive == false)
        {
            return;
        }

        duration -= Time.deltaTime;

        if (duration < 0.0f)
        {
            isActive = false;

            if (endEvent != null)
            {
                endEvent.Invoke();
            }
        }
    }
}
