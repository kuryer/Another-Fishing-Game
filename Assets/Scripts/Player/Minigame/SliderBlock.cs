using UnityEngine;

public class SliderBlock : MonoBehaviour
{
    int blockAmount;
    [SerializeField] RectTransform rectTransform;
    public void Setup(int lives, float position)
    {
        blockAmount = lives;
        Debug.Log(position);
        rectTransform.anchoredPosition = new Vector3(position,0,0);
    }

    public bool ReceiveAttack()
    {
        blockAmount--;
        if(blockAmount <= 0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
