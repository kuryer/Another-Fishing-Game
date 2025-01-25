using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFishShowcase : MonoBehaviour
{
    [SerializeField] Transform showcaseCamera;
    [SerializeField] GameObject playerModel;
    [SerializeField] float rotationTime;
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] FishValue currentFish;
    [SerializeField] SpriteRenderer fishShowcaseRenderer;
    [SerializeField] BaitValue currentBait;
    bool isShowcasing;
    [Header("State Management")]
    [SerializeField] PlayerStateManager playerStateManager;
    [SerializeField] ActivityState wanderingState;
    [Header("Animation")]
    [SerializeField] PlayerAnimation playerAnimation;
    void Start()
    {
        
    }

    public void Rotate(bool towardsCamera)
    {
        if (towardsCamera)
        {
            StartCoroutine(Rotation(new Vector3(0,180,0), new Vector3(0, 360, 0),towardsCamera));
            playerAnimation.PlayAnimation("fish_caught");
            fishShowcaseRenderer.sprite = currentFish.Item.itemSprite;
        }
        else
            StartCoroutine(Rotation(new Vector3(0, 360, 0), new Vector3(0, 180, 0), towardsCamera));
    }

    IEnumerator Rotation(Vector3 start, Vector3 dest, bool isShowcase)
    {
        float elapsedTime = 0f;
        while(elapsedTime < rotationTime)
        {
            playerModel.transform.localEulerAngles = Vector3.Lerp(start, dest, elapsedTime/rotationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerModel.transform.localEulerAngles = dest;
        if (isShowcase)
        {
            isShowcasing = true;
        }
        else
        {
            playerAnimation.PlayAnimation("idle");
            fishShowcaseRenderer.sprite = null;
        }
    }


    public void MouseInput(InputAction.CallbackContext context)
    {
        if (isShowcasing && context.performed)
            AddToEquipment();
    }

    void AddToEquipment()
    {
        isShowcasing = false;
        Rotate(false);
        playerInventory.RemoveItem(currentBait.Item);
        playerInventory.AddItem(currentFish.Item);
        currentFish.SetNull();
        playerStateManager.ChangeState(wanderingState);
    }
}
