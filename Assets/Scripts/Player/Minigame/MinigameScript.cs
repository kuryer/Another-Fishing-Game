using System.Collections.Generic;
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
    [SerializeField] FishValue currentFish;
    [SerializeField] List<SliderBlock> sliderBlocks;
    [SerializeField] List<Vector2> sliderPositions;
    [SerializeField] string blockTag;
    SliderBlock currentBlock;
    bool isBlocked;


    private void OnEnable()
    {
        minigameSliderValue.SetToDefault();
        SetupBlockades();
    }

    void SetupBlockades()
    {
        Vector2Int amountRange = currentFish.Item.blockadesAmount;
        int amountOfBlockades = Random.Range(amountRange.x, amountRange.y);
        for(int i = 0; i < sliderBlocks.Count; i++)
        {
            if(i < amountOfBlockades)
            {
                sliderBlocks[i].gameObject.SetActive(true);
                float position = Random.Range(sliderPositions[i].x, sliderPositions[i].y);
                Vector2Int livesRange = currentFish.Item.blockadesLives;
                int lives = Random.Range(livesRange.x, livesRange.y);
                sliderBlocks[i].Setup(lives, position);
            }
            else
            {
                sliderBlocks[i].gameObject.SetActive(false);
            }
        }
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
