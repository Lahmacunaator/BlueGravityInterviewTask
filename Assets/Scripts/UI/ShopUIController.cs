using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private GameObject storeItemPrefab;
    [SerializeField] private Transform storeItemParent;
    
    private List<ItemSO> playerItems;
    private List<StoreItemUI> storeItemsInScene = new();
    private bool isStoreGenerated = false;
    private PlayerInventoryController inventoryController;
    private List<ItemSO> storeItems;

    private void Awake()
    {
        PopulateStoreItems();
        GetPlayerInventory();
        GenerateStoreItems();
    }

    private void PopulateStoreItems()
    {
        storeItems = GameManager.Instance.GetAllItems();
    }

    private void GenerateStoreItems()
    {
        if (isStoreGenerated) return;
        
        foreach (var storeItem in storeItems)
        {
            var item = Instantiate(storeItemPrefab, storeItemParent);
            var itemDetails = item.GetComponent<StoreItemUI>();
            itemDetails.UpdateFields(storeItem, CheckIfItemIsPurchased(storeItem));
            storeItemsInScene.Add(itemDetails);
        }

        isStoreGenerated = true;
    }

    public void FilterWeapons()
    {
        var weapons = storeItemsInScene.Where(item => item.type == ItemType.WEAPON);
        
        foreach (var item in weapons)
            item.gameObject.SetActive(!item.gameObject.activeSelf);
    }
    
    public void FilterOutfits()
    {
        var outfits = storeItemsInScene.Where(item => item.type != ItemType.WEAPON && item.type != ItemType.FULLSET);
        
        foreach (var item in outfits)
            item.gameObject.SetActive(!item.gameObject.activeSelf);
    }
    
    public void FilterSets()
    {
        var fullSets = storeItemsInScene.Where(item => item.type == ItemType.FULLSET);
        
        foreach (var item in fullSets)
            item.gameObject.SetActive(!item.gameObject.activeSelf);
    }

    private bool CheckIfItemIsPurchased(ItemSO item) => playerItems.Contains(item);

    private void GetPlayerInventory()
    {
        inventoryController = GameManager.Instance.GetPlayerInventoryController();
        playerItems = inventoryController.GetPlayerInventory();
    }
}

public enum ShopActionResult
{
    NOTENOUGHGOLD,
    PURCHASED,
    EQUIPANOTHERITEMBEFORESELLING,
    EQUIPPED,
    SOLD,
    ERROR,
    ALREADYEQUIPPED
}
