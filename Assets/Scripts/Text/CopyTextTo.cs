using UnityEngine;
using UnityEngine.UI;

public class CopyTextTo : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void CopyTo(Text target)
    {
        target.text = text.text;
    }
}
