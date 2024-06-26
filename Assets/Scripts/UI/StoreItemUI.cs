using System;
using Core;
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
        private ItemSO _item;

        public void UpdateFields(ItemSO itemSo, bool isPurchased = false, bool isEquipped = false)
        {
            var priceToDisplay = isPurchased ? itemSo.GetSellPrice : itemSo.price;
            UpdateTitle(itemSo.itemName);
            UpdateDescription(itemSo.description);
            UpdatePrice(priceToDisplay);
            UpdateIcon(itemSo.icon);
            UpdateButton(isPurchased, isEquipped);
            UpdateType(itemSo.itemType);
            _item = itemSo;
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
            var result = inventory.HandleItemPurchase(_item);

            ShowResultText(result);
            
            if (result != ShopActionResult.PURCHASED) return;
            
            UpdateButton(true);
            UpdatePriceText(_item.GetSellPrice);
        }

        private void UpdatePriceText(int price) => priceField.text = $"{price}G";

        public void OnSellButton()
        {
            var inventory = GameManager.Instance.GetPlayerInventoryController();
        
            var result = inventory.HandleItemSale(_item);
        
            ShowResultText(result);

            if (result is ShopActionResult.ERROR or ShopActionResult.EQUIPANOTHERITEMBEFORESELLING) return;
        
            UpdateButton(false);
            UpdatePriceText(_item.price);
        }

        private void ShowResultText(ShopActionResult result)
        {
            var resultText = Instantiate(resultTextPrefab, transform);
            var textArea = resultText.GetComponent<TMP_Text>();
            switch (result)
            {
                case ShopActionResult.NOTENOUGHGOLD:
                    textArea.text = $"You don't have enough gold to buy {_item.itemName}";
                    break;
                case ShopActionResult.PURCHASED:
                    textArea.color = Color.green;
                    textArea.text = "Purchased successfully!";
                    break;
                case ShopActionResult.EQUIPANOTHERITEMBEFORESELLING:
                    textArea.text = $"Equip Another Item before selling the {_item.itemName}.";
                    break;
                case ShopActionResult.EQUIPPED:
                    textArea.color = Color.green;
                    textArea.text = $"Equipped {_item.itemName} successfully.";
                    break;
                case ShopActionResult.SOLD:
                    textArea.color = Color.green;
                    textArea.text = $"Sold {_item.itemName}";
                    break;
                case ShopActionResult.ERROR:
                    textArea.text = "An error has occured";
                    break;
                case ShopActionResult.ALREADYEQUIPPED:
                    textArea.text = $"{_item.itemName} is already equipped";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
            Destroy(textArea, 2);
        }
    
        public void OnEquipButton()
        {
            var inventoryController = GameManager.Instance.GetPlayerInventoryController();
            var result = inventoryController.EquipItem(_item);
            UpdateButton(true, true);
            ShowResultText(result.Item1);
        }

        private void UpdateType(ItemType itemType) => type = itemType;
        private void UpdateIcon(Sprite icon) => iconField.sprite = icon;
        private void UpdatePrice(int price) => priceField.text = $"{price}";
        private void UpdateDescription(string description) => descriptionField.text = description;
        private void UpdateTitle(string title) => titleField.text = title;
        public ItemSO GetItem() => _item;
    }
}
