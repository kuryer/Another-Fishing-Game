using TMPro;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class SliderBlock : MonoBehaviour
{
    int blockAmount;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] TextMeshProUGUI livesText;
    public void Setup(int lives, float position)
    {
        blockAmount = lives;
        livesText.text = lives.ToString();
        rectTransform.anchoredPosition = new Vector3(position,0,0);
    }

    public bool ReceiveAttack()
    {
        blockAmount--;
        livesText.text = blockAmount.ToString();
        if (blockAmount <= 0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
