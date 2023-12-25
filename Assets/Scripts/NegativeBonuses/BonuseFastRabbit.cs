using UnityEngine;

public class BonuseFastRabbit : BonuseSpeed
{
    protected override void BeginEvent()
    {
        startSpeed = playerMovement.Speed;
        playerMovement.Speed = startSpeed * 4;
    }
}
