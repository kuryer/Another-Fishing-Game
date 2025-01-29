using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] StringVariable sceneName;
    [SerializeField] BoolVariable startsHovering;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartPressed()
    {
        sceneName.Variable = "Main Scene";
        startsHovering.Variable = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName.Variable);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
