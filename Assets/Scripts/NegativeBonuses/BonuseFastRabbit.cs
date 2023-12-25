using UnityEngine;

public class BonuseFastRabbit : CTimerBonuse
{
    [SerializeField] private PlayerMovementController playerMovement = null;
    private float startSpeed = 0f;

    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovementController>();
        }
    }

    protected override void BeginEvent()
    {
        startSpeed = playerMovement.Speed;
        playerMovement.Speed = startSpeed * 4;
    }

    protected override void EndEvent()
    {
        playerMovement.Speed = startSpeed;
    }
}
