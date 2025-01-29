using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    [SerializeField] GameObject playerInventoryUI;

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        if (playerInventoryUI.activeInHierarchy)
            return;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
