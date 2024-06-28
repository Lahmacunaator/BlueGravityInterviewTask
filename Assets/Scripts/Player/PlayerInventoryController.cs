using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private int gold = 0;
    public List<ItemSO> inventory;
    public List<ItemSO> equippedItems;
    private PlayerOutfitController outfitController;
    
    private void Awake()
    {
        outfitController = GetComponent<PlayerOutfitController>();
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

    private void AddItem(ItemSO item)
    {
        inventory.Add(item);
    }

    public void AddGold(int value) => gold += value;
    public void RemoveGold(int value) => gold -= value;
    
    public bool TryRemoveItem(ItemSO item)
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
        AddItem(item);
        RemoveGold(item.price);
        return ShopActionResult.PURCHASED;
    }

    public List<ItemSO> GetPlayerInventory() => inventory;
}
