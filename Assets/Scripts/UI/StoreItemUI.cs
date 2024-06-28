using System;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StoreItemUI : MonoBehaviour
    {
        [Header("Fields")] 
        [SerializeField] private TMP_Text priceField;
        [SerializeField] private TMP_Text titleField;
        [SerializeField] private TMP_Text descriptionField;
        [SerializeField] private Image iconField;
        [SerializeField] private GameObject buyButton;
        [SerializeField] private GameObject equipButton;
        [SerializeField] private GameObject sellButton;
        [SerializeField] private GameObject resultTextPrefab;

        public ItemType type;
        private ItemSO item;

        public void UpdateFields(ItemSO itemSo, bool isPurchased = false, bool isEquipped = false)
        {
            UpdateTitle(itemSo.itemName);
            UpdateDescription(itemSo.description);
            UpdatePrice(itemSo.price);
            UpdateIcon(itemSo.icon);
            UpdateButton(isPurchased, isEquipped);
            UpdateType(itemSo.itemType);
            item = itemSo;
        }
    
        private void UpdateButton(bool isPurchased, bool isEquipped = false)
        {
            buyButton.SetActive(!isPurchased);
            equipButton.SetActive(isPurchased && !isEquipped);
            sellButton.SetActive(isPurchased);
        }

        public void OnBuyButton()
        {
            var inventory = GameManager.Instance.GetPlayerInventoryController();
        
            var result = inventory.HandleItemPurchase(item);
            UpdateButton(true);
            UpdatePriceText(item.GetSellPrice);
            
            ShowResultText(result);
        }

        private void UpdatePriceText(int price) =>priceField.text = $"{price}G";

        public void OnSellButton()
        {
            var inventory = GameManager.Instance.GetPlayerInventoryController();
        
            var result = inventory.HandleItemSale(item);
        
            ShowResultText(result);

            if (result is ShopActionResult.ERROR or ShopActionResult.EQUIPANOTHERITEMBEFORESELLING) return;
        
            UpdateButton(false);
            UpdatePriceText(item.price);
        }

        private void ShowResultText(ShopActionResult result)
        {
            var resultText = Instantiate(resultTextPrefab, transform);
            var textArea = resultText.GetComponent<TMP_Text>();
            switch (result)
            {
                case ShopActionResult.NOTENOUGHGOLD:
                    textArea.text = $"You don't have enough gold to buy {item.itemName}";
                    break;
                case ShopActionResult.PURCHASED:
                    textArea.color = Color.green;
                    textArea.text = "Purchased successfully!";
                    break;
                case ShopActionResult.EQUIPANOTHERITEMBEFORESELLING:
                    textArea.text = $"Equip Another Item before selling the {item.itemName}.";
                    break;
                case ShopActionResult.EQUIPPED:
                    textArea.color = Color.green;
                    textArea.text = $"Equipped {item.itemName} successfully.";
                    break;
                case ShopActionResult.SOLD:
                    textArea.color = Color.green;
                    textArea.text = $"Sold {item.itemName}";
                    break;
                case ShopActionResult.ERROR:
                    textArea.text = "An error has occured";
                    break;
                case ShopActionResult.ALREADYEQUIPPED:
                    textArea.text = $"{item.itemName} is already equipped";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
            Destroy(textArea, 2);
        }
    
        public void OnEquipButton()
        {
            var inventoryController = GameManager.Instance.GetPlayerInventoryController();
            var result = inventoryController.EquipItem(item);
            UpdateButton(true, true);
            ShowResultText(result);
        }

        private void UpdateType(ItemType itemType) => type = itemType;
        private void UpdateIcon(Sprite icon) => iconField.sprite = icon;
        private void UpdatePrice(int price) => priceField.text = $"{price}";
        private void UpdateDescription(string description) => descriptionField.text = description;
        private void UpdateTitle(string title) => titleField.text = title;
    }
}
