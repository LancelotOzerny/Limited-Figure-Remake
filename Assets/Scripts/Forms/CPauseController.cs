using UnityEngine;

public class CPauseController : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            bool state = !pause.activeSelf;

            if (state)
            {
                SetPause();
            }
            else
            {
                OffPause();
            }
        }
    }

    public void SetPause()
    {
        if (pause == null)
        {
            return;
        }

        pause.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void OffPause()
    {
        if (pause == null)
        {
            return;
        }

        pause.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
