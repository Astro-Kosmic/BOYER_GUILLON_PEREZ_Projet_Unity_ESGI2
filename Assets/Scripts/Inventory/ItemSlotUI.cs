using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;

    public void SetSlot(ItemData item, int quantity)
    {
        if (item == null)
        {
            iconImage.enabled = false;
            quantityText.text = "";
            return;
        }

        iconImage.enabled = true;
        iconImage.sprite = item.icon;

        quantityText.text = quantity > 1 ? $"x{quantity}" : "";
    }
}

