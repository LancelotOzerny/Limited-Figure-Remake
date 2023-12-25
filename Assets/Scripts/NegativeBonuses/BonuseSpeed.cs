using UnityEngine;

public abstract class BonuseSpeed : CTimerBonuse
{
    [SerializeField] protected PlayerMovementController playerMovement = null;
    protected float startSpeed = 0f;

    protected void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovementController>();
        }
    }

    protected override void EndEvent()
    {
        playerMovement.Speed = startSpeed;
    }
}
