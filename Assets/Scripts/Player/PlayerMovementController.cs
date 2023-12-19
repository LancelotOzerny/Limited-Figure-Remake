using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private PlayerPointsManager points;
    private bool backMovement = false;

    private void Awake()
    {
        points = GetComponent<PlayerPointsManager>();
    }

    private void Start()
    {
        if (points == null && points.Current != null)
        {
            return;
        }

        transform.position = points.Current.position;
        points.Next();
    }

    private void Update()
    {
        if (points == null) 
        {
            return;
        }

        Transform current = points.Current;
        KeyDown();

        if (current ==  null)
        {
            return;
        }

        Vector2 pos = transform.position;
        Vector2 target = current.position;

        float distance = Vector2.Distance(pos, target);
        transform.position = Vector2.Lerp(pos, target, speed * Time.deltaTime / distance);

        if (distance < 0.1f)
        {
            if (backMovement)
            {
                points.Prev();
            }
            else
            {
                points.Next();
            }
        }
    }

    private void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            backMovement = !backMovement;
            points.Change();
        }
    }
}
