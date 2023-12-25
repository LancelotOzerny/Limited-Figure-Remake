using UnityEngine;

public class BonuseTurtle: BonuseSpeed
{
    protected override void BeginEvent()
    {
        startSpeed = playerMovement.Speed;
        playerMovement.Speed = startSpeed / 4;
    }
}
