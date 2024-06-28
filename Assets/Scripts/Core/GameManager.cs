using System;
using System.Collections.Generic;
using Player;
using ScriptableObjects;
using UI;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public UIManager uiManager;
        public CameraController cameraController;
    
        [SerializeField] private List<ItemSO> allItems;
        private GameObject _player;
        private GameState _state = GameState.PLAYING;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        
            _player = GameObject.FindWithTag("Player");
        }

        public void ChangeGameState(GameState gameState)
        {
            _state = gameState;
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

        public PlayerOutfitController GetPlayerOutfitController() =>  _player.GetComponent<PlayerOutfitController>();
        public PlayerInventoryController GetPlayerInventoryController() =>  _player.GetComponent<PlayerInventoryController>();
        private PlayerMovement GetPlayerMover() =>  _player.GetComponent<PlayerMovement>();

        public List<ItemSO> GetAllItems() => allItems;
        public GameState GetState() => _state;
    }

    public enum GameState
    {
        PLAYING,
        SHOPPING
    }
}