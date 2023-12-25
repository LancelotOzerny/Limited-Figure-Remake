using UnityEngine;

public class AsteroidGenerator : CAreaGenerator
{
    [SerializeField] private SpriteRenderer toArea;

    protected override void Generate()
    {
        GameObject newObj = CreateNewObject();
        SetPositionFrom(newObj);

        newObj.GetComponent<CAsteroid>().SetTarget(new Vector2(
            rand.Next(
                (int)(toArea.transform.position.x * epsilon),
                (int)(toArea.transform.position.x * epsilon + fromArea.bounds.size.x * epsilon)
            ) / epsilon - toArea.bounds.size.x / 2,
            toArea.gameObject.transform.position.y
        ));
    }
}
