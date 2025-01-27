using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;
    public void PauseInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
            optionsPanel.SetActive(false);
        }
        CheckFreezeTime();
    }

    void CheckFreezeTime()
    {
        if (pausePanel.activeInHierarchy)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Debug.Log("Exit Button");
    }
}
