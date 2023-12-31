using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] AudioSource changeDirectionSound = null;
    [SerializeField] private PlayerPointsManager points = null;
    private bool backMovement = false;

    public float Speed 
    { 
        get => speed;
        set => speed = value;
    }

    private void Awake()
    {
        if (points == null)
        {
            points = GetComponent<PlayerPointsManager>();
        }
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

        KeyDown();
        Move();
    }

    private void Move()
    {
        Transform current = points.Current;
        if (current == null)
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
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        backMovement = !backMovement;
        points.Change();

        if (changeDirectionSound != null)
        {
            changeDirectionSound.Play();
        }
    }
}
