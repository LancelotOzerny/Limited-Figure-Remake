using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CToggleOption : CPrefValueBool
{
    [SerializeField] private Toggle toggle;

    [SerializeField] private UnityEvent on;
    [SerializeField] private UnityEvent off;

    public override void Load()
    {
        base.Load();
        Action();

        if (toggle != null)
        {
            toggle.isOn = this.current_value;
        }
    }

    public void Change()
    {
        if (toggle != null)
        {
            this.current_value = toggle.isOn;
        }

        Action();
        Save();
    }

    public void Action()
    {
        if (this.current_value)
        {
            on.Invoke();
        }
        else
        {
            off.Invoke();
        }
    }
}
