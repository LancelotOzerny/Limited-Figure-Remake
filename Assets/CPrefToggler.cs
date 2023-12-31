using UnityEngine;
using UnityEngine.UI;

public class CPrefToggler : CPrefValueBool
{
    [SerializeField] private Toggle toggler;

    private void Start()
    {
        toggler.isOn = this.current_value;
        StartEvents();
    }

    public void Change()
    {
        this.current_value = !this.current_value;
        toggler.isOn = this.current_value;
        StartEvents();
    }

    public void StartEvents()
    {

    }
}
