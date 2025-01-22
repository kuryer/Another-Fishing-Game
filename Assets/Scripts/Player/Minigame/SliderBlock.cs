using UnityEngine;

public class SliderBlock : MonoBehaviour
{
    [SerializeField] float blockAmount;

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
