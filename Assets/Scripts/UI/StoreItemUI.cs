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

    public ItemType type;
    private ItemSO item;

    public void UpdateFields(ItemSO itemSo, bool isPurchased = false)
    {
        UpdateTitle(itemSo.itemName);
        UpdateDescription(itemSo.description);
        UpdatePrice(itemSo.price);
        UpdateIcon(itemSo.icon);
        UpdateButton(isPurchased);
        UpdateType(itemSo.itemType);
        item = itemSo;
    }
    
    private void UpdateButton(bool isPurchased)
    {
        buyButton.SetActive(!isPurchased);
        equipButton.SetActive(isPurchased);
    }

    public void OnBuyButton()
    {
        UpdateButton(true);
    }
    
    public void OnEquipButton()
    {
        var inventoryController = GameManager.Instance.GetPlayerInventoryController();
        inventoryController.EquipItem(item);
    }

    private void UpdateType(ItemType itemType) => type = itemType;
    private void UpdateIcon(Sprite icon) => iconField.sprite = icon;
    private void UpdatePrice(int price) => priceField.text = $"{price}";
    private void UpdateDescription(string description) => descriptionField.text = description;
    private void UpdateTitle(string title) => titleField.text = title;
}
