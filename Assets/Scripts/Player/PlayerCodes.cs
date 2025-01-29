using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCodes : MonoBehaviour
{
    [SerializeField] IntVariable playerMoney;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] string sceneName;


    public void Motherlode(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMoney.Variable += 100;
            playerInventory.UpdateMoney();
        }
    }

    public void ReloadScene(InputAction.CallbackContext context)
    {
        if(context.performed)
            SceneManager.LoadScene(sceneName);
    }
}
