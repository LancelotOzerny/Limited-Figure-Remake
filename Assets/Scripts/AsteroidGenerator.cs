using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer from;    
    [SerializeField] private SpriteRenderer to;
    [SerializeField] private List<GameObject> generateList = new List<GameObject>();

    [SerializeField] private int epsilon = 10_000;
    private static System.Random rand = new System.Random();

    [SerializeField] private float minTime = 1.0f;
    [SerializeField] private float maxTime = 2.0f;
    [SerializeField] private float time;

    private void Start()
    {
        time = minTime + rand.Next(0, (int)(epsilon * (maxTime - minTime))) / epsilon;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = minTime + rand.Next(0, (int)(epsilon * (maxTime - minTime))) / epsilon;
            Create();
        }
    }

    private void Create()
    {
        if (generateList.Count == 0)
        {
            return;
        }

        int generateIndex = rand.Next(generateList.Count);
        GameObject newObj = Instantiate(generateList[generateIndex], transform);

        Vector2 fromPos = from.transform.position;
        Vector2 toPos = to.transform.position;

        newObj.transform.position = new Vector2(
            rand.Next(
                (int)(fromPos.x * epsilon), 
                (int)(fromPos.x * epsilon + from.bounds.size.x * epsilon)
            ) / epsilon - from.bounds.size.x / 2,
            from.gameObject.transform.position.y
        );

        newObj.GetComponent<CAsteroid>().SetTarget(new Vector2(
            rand.Next(
                (int)(toPos.x * epsilon),
                (int)(toPos.x * epsilon + from.bounds.size.x * epsilon)
            ) / epsilon - to.bounds.size.x / 2,
            to.gameObject.transform.position.y
        ));
    }
}
