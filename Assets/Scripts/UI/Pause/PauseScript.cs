using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;

    [Header("Exit")]
    [SerializeField] StringVariable sceneName;
    [SerializeField] BoolVariable startsHovering;
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
        if (pausePanel.activeInHierarchy && !startsHovering.Variable)
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

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName.Variable);
    }

    public void ExitButtonPressed()
    {
        sceneName.Variable = "Main Menu";
        Time.timeScale = 1f;
        startsHovering.Variable = true;
    }
}
