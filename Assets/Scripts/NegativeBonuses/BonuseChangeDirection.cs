using UnityEngine;

public class BonuseChangeDirection : MonoBehaviour
{
    [SerializeField] private PlayerMovementController movement = null;

    private void Awake()
    {
        if (movement == null)
        {
            movement = GetComponent<PlayerMovementController>();
        }
    }

    public void Activate()
    {
        movement.ChangeDirection();
    }
}
