using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinigameScript : MonoBehaviour
{
    bool isHold;
    [SerializeField] FloatVariable minigameSliderValue;
    [SerializeField] Slider minigameSlider;
    [SerializeField] float sliderSpeed;

    [Header("Blocks")]
    [SerializeField] string blockTag;
    SliderBlock currentBlock;
    bool isBlocked;


    private void OnEnable()
    {
        minigameSliderValue.SetToDefault();
    }

    private void Update()
    {
        if (isHold && !isBlocked)
            AddValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(blockTag))
        {
            currentBlock = collision.GetComponent<SliderBlock>();
            BlockSlider();
        }
    }

    void BlockSlider()
    {
        isBlocked = true;
    }

    private void AddValue()
    {
        minigameSliderValue.Variable += sliderSpeed * Time.deltaTime;
        if (minigameSliderValue.Variable >= 100f)
            WinMinigame();
        minigameSlider.value = minigameSliderValue.Variable;
    }

    private void WinMinigame()
    {
        Debug.Log("Minigame won");
        enabled = false;
        minigameSliderValue.SetToDefault();
    }

    public void GetMouseInput(InputAction.CallbackContext context)
    {
        if (!enabled)
            return;
        if (isBlocked && context.started)
            AttackBlock();

        isHold = context.performed;
    }

    void AttackBlock()
    {
        bool isBlockDefeated = currentBlock.ReceiveAttack();
        if (isBlockDefeated)
            isBlocked = false;
    }
}
