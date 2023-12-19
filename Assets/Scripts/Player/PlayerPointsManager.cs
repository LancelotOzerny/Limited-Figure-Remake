using System.Collections.Generic;
using UnityEngine;

public class PlayerPointsManager : MonoBehaviour
{
    [SerializeField] private List<Transform> movePoints = new List<Transform>();
    
    private int currentIndex = -1;

    public Transform Current
    {
        get
        {
            return currentIndex >= 0 ? movePoints[currentIndex] : null;
        }
    }

    private void Awake()
    {
        if (movePoints.Count > 0)
        {
            currentIndex = 0;
        }
    }

    public void Next()
    {
        if (movePoints.Count == 0)
        {
            return;
        }

        currentIndex++;

        if (currentIndex >= movePoints.Count)
        {
            currentIndex = 0;
        }
    }
}
