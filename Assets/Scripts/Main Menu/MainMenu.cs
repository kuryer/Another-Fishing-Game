using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string gameSceneName;


    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
