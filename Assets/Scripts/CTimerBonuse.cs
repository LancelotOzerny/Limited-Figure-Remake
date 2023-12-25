using UnityEngine;

public abstract class CTimerBonuse : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float duration = 1.0f;
    private float startDuration;
    private bool isActive = false;

    protected abstract void BeginEvent();
    protected abstract void EndEvent();

    protected void Start()
    {
        startDuration = duration;
    }

    public void Active()
    {
        if (isActive)
        {
            duration = startDuration;
            return;
        }

        isActive = true;
        duration = startDuration;
        BeginEvent();
    }

    protected void Update()
    {
        if (isActive == false)
        {
            return;
        }

        duration -= Time.deltaTime;

        if (duration < 0.0f)
        {
            isActive = false;
            EndEvent();
        }
    }
}
