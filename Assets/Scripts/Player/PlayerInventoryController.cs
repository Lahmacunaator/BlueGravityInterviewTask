using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private int gold = 0;
    private List<ItemSO> inventory = new();
    private List<ItemSO> equippedItems = new();
    private PlayerOutfitController outfitController;
    
    private void Awake()
    {
        outfitController = GetComponent<PlayerOutfitController>();
    }

    public void EquipItem(ItemSO item)
    {
        outfitController.ApplyEquipItemVisuals(item);
        AddItem(item);
    }
    
    public void AddItem(ItemSO item)
    {
        inventory.Add(item);
    }

    public void AddGold(int value) => gold += value;
    
    public bool TryRemoveItem(ItemSO item)
    {
        if (!inventory.Contains(item)) return false;
        
        inventory.Remove(item);
        return true;
    }

    public void ApplyItemSale(ItemSO item)
    {
        var canProceed = TryRemoveItem(item);

        if (canProceed)
            AddGold(item.GetSellPrice);
    }

    public List<ItemSO> GetPlayerInventory() => inventory;
}
