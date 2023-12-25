using UnityEngine;

public abstract class CIntervalGenerator : MonoBehaviour
{
    [Header("Generate Timer Options")]
    [SerializeField] protected float time = 0.0f;
    [SerializeField] protected float minTime = 1.0f;
    [SerializeField] protected float maxTime = 2.0f;
    [SerializeField] protected int epsilon = 10_000;

    protected static System.Random rand = new System.Random();

    protected void Start()
    {
        time = minTime + rand.Next(0, (int)(epsilon * (maxTime - minTime))) / epsilon;
    }

    protected void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = minTime + rand.Next(0, (int)(epsilon * (maxTime - minTime))) / epsilon;
            Generate();
        }
    }

    protected abstract void Generate();
}
