using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform playerTargetPos;
    [SerializeField] private Transform cameraTargetPos;
    private bool isInShop;
    private Vector2 playerInitialPos;
    private Vector2 cameraInitialPos;

    public void EnterShop()
    {
        player.localScale = Vector3.one * 0.15f;
        player.position = playerTargetPos.position;
        mainCamera.transform.position = cameraTargetPos.position;
        isInShop = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (isInShop)
            {
                LeaveShop();
            }
            else
            {
                EnterShop();
            }
            
        }
    }

    private void LeaveShop()
    {
        player.localScale = Vector3.one * 0.1f;
        mainCamera.transform.position = new Vector3(cameraInitialPos.x, cameraInitialPos.y, -10f);
        player.position = playerInitialPos;
        isInShop = false;
    }

    private void Start()
    {
        playerInitialPos = player.position;
        cameraInitialPos = mainCamera.transform.position;
        
        player.localScale = Vector3.one * 0.1f;
    }
    void Update()
    {
        
    }
}
