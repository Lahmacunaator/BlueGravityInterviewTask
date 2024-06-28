using UnityEngine;

namespace Core
{
    public class Shopkeeper : MonoBehaviour
    {
        private Transform _playerTransform;
        public GameObject shopTooltip;
        public float playerDistanceForTooltip = 2f;

        private void Awake()
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (Vector2.Distance(_playerTransform.position, transform.position) >= playerDistanceForTooltip)
            {
                shopTooltip.SetActive(false);
                return;
            }

            var isShopping = GameManager.Instance.GetState() == GameState.SHOPPING;
        
            if (!shopTooltip.activeSelf) 
                shopTooltip.SetActive(!isShopping);
            else
                shopTooltip.SetActive(!isShopping);

            if (Input.GetKeyDown(KeyCode.E) && shopTooltip.activeSelf)
            {
                GameManager.Instance.ChangeGameState(GameState.SHOPPING);
            }
        }
    }
}
