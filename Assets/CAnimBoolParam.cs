using UnityEngine;

public class CAnimBoolParam : MonoBehaviour
{
    [SerializeField] private Animator anim = null;

    private void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    public void TurnOnBoolean(string name)
    {
        anim.SetBool(name, true);
    }

    public void TurnOffBoolean(string name)
    {
        anim.SetBool(name, false);
    }
}
