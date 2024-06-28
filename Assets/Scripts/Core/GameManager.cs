using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private List<ItemSO> AllItems;
    private GameObject player;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        player = GameObject.FindWithTag("Player");
    }

    public PlayerOutfitController GetPlayerOutfitController() =>  player.GetComponent<PlayerOutfitController>();
    public PlayerInventoryController GetPlayerInventoryController() =>  player.GetComponent<PlayerInventoryController>();

    public List<ItemSO> GetAllItems() => AllItems;
}
