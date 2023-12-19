using UnityEngine;

public class CAsteroid : MonoBehaviour
{
    Vector2 target;

    float speed;
    float maxSpeed = 16f;
    float minSpeed = 3f;

    private static System.Random rand = new System.Random();
    private int epsilon = 10_000;

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    private void Start()
    {
        this.speed = rand.Next((int)(minSpeed * epsilon), (int)(maxSpeed * epsilon)) / epsilon;
    }

    private void Update()
    {
        float distance = Vector2.Distance(this.transform.position, this.target);

        transform.position = Vector2.Lerp(
            transform.position, 
            this.target, 
            this.speed / distance * Time.deltaTime
        );

        if (distance <= 0.1f)
        {
            GameObject.Destroy( this.gameObject );
        }
    }
}
