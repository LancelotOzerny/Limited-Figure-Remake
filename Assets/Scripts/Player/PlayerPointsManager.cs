using System.Collections.Generic;
using UnityEngine;

public class PlayerPointsManager : MonoBehaviour
{
    [SerializeField] private List<Transform> movePoints = new List<Transform>();
    
    private int currentIndex = -1;
    private int lastIndex = -1;

    public Transform Current
    {
        get
        {
            return currentIndex >= 0 ? movePoints[currentIndex] : null;
        }
    }

    private void Awake()
    {
        if (movePoints.Count == 0)
        {
            return;
        }

        currentIndex = 0;
        lastIndex = movePoints.Count - 1;
    }

    public void Next()
    {
        if (movePoints.Count == 0)
        {
            return;
        }

        lastIndex = currentIndex;
        currentIndex++;

        if (currentIndex >= movePoints.Count)
        {
            currentIndex = 0;
        }
    }

    public void Prev()
    {
        if (movePoints.Count == 0)
        {
            return;
        }

        lastIndex = currentIndex;
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = movePoints.Count - 1;
        }
    }

    public void Change()
    {
        int temp = lastIndex;
        lastIndex = currentIndex;
        currentIndex = temp;
    }
}
