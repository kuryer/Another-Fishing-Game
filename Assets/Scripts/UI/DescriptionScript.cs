using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DescriptionScript : MonoBehaviour
{
    string description;
    string itemName;
    [SerializeField] Vector2 offset;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI itemNameText;

    public void SetName(string name)
    {
        itemName = name;
        itemNameText.text = name;
    }

    public void Setup(string desc)
    {
        description = desc;
        descriptionText.text = description;
        gameObject.SetActive(true);
    }

    void Update()
    {
        CursorAim();
    }

    void CursorAim()
    {
        transform.position = Mouse.current.position.ReadValue() + offset;
    }
}
