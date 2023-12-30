using UnityEngine;

public class CImageAreaGenerator : CIntervalGenerator
{
    [SerializeField] private GameObject pref;
    [SerializeField] private RectTransform area;

    protected override void Generate()
    {
        if (pref == null || area.rect == null)
        {
            return;
        }

        GameObject obj = Instantiate(pref, transform);
        RectTransform objRect = obj.GetComponent<RectTransform>();
        objRect.localPosition = GetRandomPosition();

        float scale = (float)(rand.Next(0, epsilon)) / epsilon;
        objRect.sizeDelta *= scale;
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 from = new Vector2(area.rect.x, area.rect.y);
        Vector2 to = new Vector2(area.rect.x + area.rect.width, area.rect.y + area.rect.height);

        return new Vector2(
            rand.Next((int)(from.x * epsilon), (int)(to.x * epsilon)) / epsilon,
            rand.Next((int)(from.y * epsilon), (int)(to.y * epsilon)) / epsilon
        );
    }
}
