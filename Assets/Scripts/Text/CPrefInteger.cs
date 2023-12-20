using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class CPrefInteger : MonoBehaviour
{
    [Header("Integer Prefab Settings")]
    [SerializeField] protected string prefName;
    [SerializeField] protected int value;

    public void Load()
    {
        if (PlayerPrefs.HasKey(prefName))
        {
            this.value = PlayerPrefs.GetInt(prefName);
        }
        else
        {
            this.value = 0;
        }
    }

    public void TrySave(int value)
    {
        if (this.value < value)
        {
            PlayerPrefs.SetInt(prefName, value);
            this.value = value;
        }
    }
}
