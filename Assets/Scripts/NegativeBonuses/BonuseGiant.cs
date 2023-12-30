using UnityEngine;

public class BonuseGiant : CTimerBonuse
{
    [SerializeField] private Animator anim = null;
    private void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    protected override void BeginEvent()
    {
        anim.SetBool("isGiant", true);
    }

    protected override void EndEvent()
    {
        anim.SetBool("isGiant", false);
    }
}
