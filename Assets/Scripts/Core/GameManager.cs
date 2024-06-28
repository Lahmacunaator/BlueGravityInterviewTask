using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private List<ItemSO> AllItems;
    private GameObject player;
    private GameState state;
    
    
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

    public void ChangeGameState(GameState gameState)
    {
        state = gameState;
        HandleStateChange(gameState);
    }

    private void HandleStateChange(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.PLAYING:
                break;
            case GameState.SHOPPING:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }

    public PlayerOutfitController GetPlayerOutfitController() =>  player.GetComponent<PlayerOutfitController>();
    public PlayerInventoryController GetPlayerInventoryController() =>  player.GetComponent<PlayerInventoryController>();
    public PlayerMovement GetPlayerMover() =>  player.GetComponent<PlayerMovement>();

    public List<ItemSO> GetAllItems() => AllItems;
}

public enum GameState
{
    PLAYING,
    SHOPPING
}