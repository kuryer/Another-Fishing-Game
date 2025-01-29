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

    [SerializeField] GameEvent onShowCursor;
    [SerializeField] GameEvent onHideCursor;

    private void Start()
    {
        sceneName.Variable = null;
    }

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
            onShowCursor.Raise();
        }
        else
        {
            ResumeButton();
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        onHideCursor.Raise();
    }

    public void LoadScene()
    {
        if(sceneName.Variable is not null)
            SceneManager.LoadScene(sceneName.Variable);
    }

    public void ExitButtonPressed()
    {
        sceneName.Variable = "Main Menu";
        Time.timeScale = 1f;
        startsHovering.Variable = true;
    }
}
