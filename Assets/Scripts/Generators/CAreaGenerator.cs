using System.Collections.Generic;
using UnityEngine;

public class CAreaGenerator : CIntervalGenerator
{
    [Header("Generate General Options")]
    [SerializeField] protected SpriteRenderer fromArea;
    [SerializeField] protected List<GameObject> generateList = new List<GameObject>();

    protected override void Generate()
    {
        GameObject obj = CreateNewObject();
        SetPositionFrom(obj);
    }

    protected GameObject CreateNewObject()
    {
        if (generateList.Count == 0)
        {
            return null;
        }

        int generateIndex = rand.Next(generateList.Count);
        GameObject newObj = Instantiate(generateList[generateIndex], transform);

        return newObj;
    }

    protected void SetPositionFrom(GameObject newObj)
    {
        newObj.transform.position = new Vector2(
            rand.Next(
                (int)(fromArea.transform.position.x * epsilon),
                (int)(fromArea.transform.position.x * epsilon + fromArea.bounds.size.x * epsilon)
            ) / epsilon - fromArea.bounds.size.x / 2,
            fromArea.gameObject.transform.position.y
        );
    }
}
