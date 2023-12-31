using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private List<PointsGroup> pointGroups = new List<PointsGroup>();

    private int currentGroup = 0;

    private int lastIndex = 0;
    private int currentIndex = 0;

    public Transform Current 
    {  
        get => (IsCorrect() ? pointGroups[currentGroup].points[currentIndex] : null); 
    }

    public void Next()
    {
        if (IsCorrect() == false)
        {
            return;
        }

        lastIndex = currentIndex;

        if (++currentIndex >= pointGroups[currentGroup].Count)
        {
            currentIndex = 0;
        }
    }

    public void Prev()
    {
        if (IsCorrect() == false)
        {
            return;
        }

        lastIndex = currentIndex;

        if (--currentIndex < 0)
        {
            currentIndex = pointGroups[currentGroup].Count - 1;
        }
    }

    public void Change()
    {
        int temp = lastIndex;
        lastIndex = currentIndex;
        currentIndex = temp;
    }

    public void SetGroup(string title)
    {
        for (int i = 0; i < pointGroups.Count; i++)
        {
            if (pointGroups[i].title == title)
            {
                currentGroup = i;
                break;
            }
        }
    }

    public bool IsCorrect()
    {
        if (pointGroups.Count == 0)
        {
            return false;
        }

        if (pointGroups[currentGroup].Count == 0)
        {
            return false;
        }

        return true;
    }
}

[System.Serializable]
public class PointsGroup
{
    public string title = string.Empty;
    public List<Transform> points = new List<Transform>();

    public int Count { get { return points.Count; } }
}
