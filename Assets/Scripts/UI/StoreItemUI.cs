using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    [Header("Fields")] 
    [SerializeField] private TMP_Text priceField;
    [SerializeField] private TMP_Text titleField;
    [SerializeField] private TMP_Text descriptionField;
    [SerializeField] private Image iconField;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject equipButton;

    public void UpdateFields(string title, string description, int price, Sprite icon, bool isPurchased = false)
    {
        UpdateTitle(title);
        UpdateDescription(description);
        UpdatePrice(price);
        UpdateIcon(icon);
        UpdateButton(isPurchased);
    }

    private void UpdateButton(bool isPurchased)
    {
        buyButton.SetActive(!isPurchased);
        equipButton.SetActive(isPurchased);
    }

    private void UpdateIcon(Sprite icon) => iconField.sprite = icon;
    private void UpdatePrice(int price) => priceField.text = $"{price}";
    private void UpdateDescription(string description) => descriptionField.text = description;
    private void UpdateTitle(string title) => titleField.text = title;
}
