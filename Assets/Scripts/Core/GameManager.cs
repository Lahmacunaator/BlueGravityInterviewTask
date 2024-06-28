using System;
using System.Collections.Generic;
using Player;
using ScriptableObjects;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public CameraController cameraController;
    
    [SerializeField] private List<ItemSO> AllItems;
    private GameObject player;
    private GameState state = GameState.PLAYING;
    
    
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
        var playerMover = GetPlayerMover();
        playerMover.enabled = gameState switch
        {
            GameState.PLAYING => true,
            GameState.SHOPPING => false,
            _ => throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null)
        };
        uiManager.ToggleShopUI();
        cameraController.ToggleZoom();
    }

    public PlayerOutfitController GetPlayerOutfitController() =>  player.GetComponent<PlayerOutfitController>();
    public PlayerInventoryController GetPlayerInventoryController() =>  player.GetComponent<PlayerInventoryController>();
    public PlayerMovement GetPlayerMover() =>  player.GetComponent<PlayerMovement>();

    public List<ItemSO> GetAllItems() => AllItems;
    public GameState GetState() => state;
}

public enum GameState
{
    PLAYING,
    SHOPPING
}