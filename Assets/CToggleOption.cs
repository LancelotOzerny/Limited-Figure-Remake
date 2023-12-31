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
        toggle.isOn = this.current_value;
        Action();
    }

    public void Change()
    {
        this.current_value = toggle.isOn;
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
