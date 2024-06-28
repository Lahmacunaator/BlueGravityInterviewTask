using System.Collections.Generic;
using System.Linq;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace UI
{
    public class ShopUIController : MonoBehaviour
    {
        [SerializeField] private GameObject storeItemPrefab;
        [SerializeField] private Transform storeItemParent;
    
        private readonly List<StoreItemUI> _storeItemsInScene = new();
        private bool _isStoreGenerated;
        private PlayerInventoryController _inventoryController;
        private List<ItemSO> _storeItems;

        private void Awake()
        {
            PopulateStoreItems();
            GetPlayerInventory();
            GenerateStoreItems();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.ChangeGameState(GameState.PLAYING);
            }
        }

        private void PopulateStoreItems()
        {
            _storeItems = GameManager.Instance.GetAllItems();
        }

        private void GenerateStoreItems()
        {
            if (_isStoreGenerated) return;
        
            foreach (var storeItem in _storeItems)
            {
                var item = Instantiate(storeItemPrefab, storeItemParent);
                var itemDetails = item.GetComponent<StoreItemUI>();
                itemDetails.UpdateFields(storeItem, CheckIfItemIsPurchased(storeItem), CheckIfItemIsEquipped(storeItem));
                _storeItemsInScene.Add(itemDetails);
            }

            _isStoreGenerated = true;
        }

        public void FilterWeapons()
        {
            var weapons = _storeItemsInScene.Where(item => item.type == ItemType.WEAPON);
        
            foreach (var item in weapons)
                item.gameObject.SetActive(!item.gameObject.activeSelf);
        }
    
        public void FilterOutfits()
        {
            var outfits = _storeItemsInScene.Where(item => item.type != ItemType.WEAPON && item.type != ItemType.FULLSET);
        
            foreach (var item in outfits)
                item.gameObject.SetActive(!item.gameObject.activeSelf);
        }
    
        public void FilterSets()
        {
            var fullSets = _storeItemsInScene.Where(item => item.type == ItemType.FULLSET);
        
            foreach (var item in fullSets)
                item.gameObject.SetActive(!item.gameObject.activeSelf);
        }

        private bool CheckIfItemIsPurchased(ItemSO item) => _inventoryController.CheckIfItemIsPurchased(item);
        private bool CheckIfItemIsEquipped(ItemSO item) => _inventoryController.CheckIfItemIsEquipped(item);

        private void GetPlayerInventory()
        {
            _inventoryController = GameManager.Instance.GetPlayerInventoryController();
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
}