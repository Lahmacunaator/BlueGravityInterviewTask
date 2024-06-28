using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        public List<ItemSO> inventory;
        public List<ItemSO> equippedItems;
        private PlayerOutfitController _outfitController;
        private UIManager _uiManager;
        private int _gold = 2000;
        
        private void Awake()
        {
            _outfitController = GetComponent<PlayerOutfitController>();
        }

        private void Start()
        {
            _uiManager = GameManager.Instance.uiManager;
            _uiManager.UpdateGoldAmountText($"{_gold}G");
        }

        public ShopActionResult EquipItem(ItemSO item)
        {
            if (equippedItems.Contains(item)) return ShopActionResult.ALREADYEQUIPPED;
        
            _outfitController.ApplyEquipItemVisuals(item);
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
            _gold += value;
            _uiManager.UpdateGoldAmountText($"{_gold}G");
        }

        private void RemoveGold(int value)
        {
            _gold -= value;
            _uiManager.UpdateGoldAmountText($"{_gold}G");
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
        
            var canProceed = TryRemoveItem(item);

            if (canProceed)
                AddGold(item.GetSellPrice);
            else
                return ShopActionResult.ERROR;

            return ShopActionResult.SOLD;
        }
    
        public ShopActionResult HandleItemPurchase(ItemSO item)
        {
            if (_gold < item.price)
                return ShopActionResult.NOTENOUGHGOLD;
            
            AddItem(item);
            RemoveGold(item.price);
            return ShopActionResult.PURCHASED;
        }
    }
}