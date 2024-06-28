using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        private int gold = 2000;
        public List<ItemSO> inventory;
        public List<ItemSO> equippedItems;
        private PlayerOutfitController outfitController;
        private UIManager uiManager;
    
        private void Awake()
        {
            outfitController = GetComponent<PlayerOutfitController>();
        }

        private void Start()
        {
            uiManager = GameManager.Instance.uiManager;
            uiManager.UpdateGoldAmountText($"{gold}G");
        }

        public ShopActionResult EquipItem(ItemSO item)
        {
            if (equippedItems.Contains(item)) return ShopActionResult.ALREADYEQUIPPED;
        
            outfitController.ApplyEquipItemVisuals(item);
            var equippedCounterpart = equippedItems.First(i => i.itemType == item.itemType);
            equippedItems.Remove(equippedCounterpart);
            equippedItems.Add(item);

            return ShopActionResult.EQUIPPED;
        }

        public bool CheckIfItemIsPurchased(ItemSO item) => inventory.Contains(item);
        public bool CheckIfItemIsEquipped(ItemSO item) => equippedItems.Contains(item);

        private void AddItem(ItemSO item)
        {
            inventory.Add(item);
        }

        private void AddGold(int value)
        {
            gold += value;
            uiManager.UpdateGoldAmountText($"{gold}G");
        }

        private void RemoveGold(int value)
        {
            gold -= value;
            uiManager.UpdateGoldAmountText($"{gold}G");
        }

        private bool TryRemoveItem(ItemSO item)
        {
            if (!inventory.Contains(item)) return false;
        
            inventory.Remove(item);
            return true;
        }

        public ShopActionResult HandleItemSale(ItemSO item)
        {
            if (equippedItems.Contains(item))
                return ShopActionResult.EQUIPANOTHERITEMBEFORESELLING;

            if (gold < item.price)
                return ShopActionResult.NOTENOUGHGOLD;
        
            var canProceed = TryRemoveItem(item);

            if (canProceed)
                AddGold(item.GetSellPrice);
            else
                return ShopActionResult.ERROR;

            return ShopActionResult.SOLD;
        }
    
        public ShopActionResult HandleItemPurchase(ItemSO item)
        {
            AddItem(item);
            RemoveGold(item.price);
            return ShopActionResult.PURCHASED;
        }

        public List<ItemSO> GetPlayerInventory() => inventory;
    }
}
