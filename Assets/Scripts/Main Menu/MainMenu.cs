using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] StringVariable sceneName;
    [SerializeField] BoolVariable startsHovering;
    public void StartPressed()
    {
        sceneName.Variable = "SampleScene";
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
