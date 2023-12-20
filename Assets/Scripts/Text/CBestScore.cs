using UnityEngine;
using UnityEngine.UI;

public class CBestScore : CPrefInteger
{
    [Header("CBest Score Parameters")]
    [SerializeField] private string prefix = string.Empty;
    [SerializeField] private string postfix = string.Empty;
    private Text text = null;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        if (text == null)
        {
            return;
        }

        Load();
        Debug.Log(this.value);
        text.text = CTimer.ToTime(this.value);
    }
}
