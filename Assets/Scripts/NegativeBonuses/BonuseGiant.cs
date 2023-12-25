using UnityEngine;

public class BonuseGiant : CTimerBonuse
{
    [SerializeField] protected Transform player = null;
    private Vector2 startScale;

    private void Awake()
    {
        if (player == null)
        {
            player = GetComponent<Transform>();
        }
    }

    protected override void BeginEvent()
    {
        startScale = player.transform.localScale;
        player.transform.localScale = startScale * 1.75f;
    }

    protected override void EndEvent()
    {
        player.transform.localScale = startScale;
    }
}
