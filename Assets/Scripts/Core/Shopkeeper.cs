using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    private Transform playerTransform;
    public GameObject shopTooltip;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) >= 5f)
        {
            shopTooltip.SetActive(false);
            return;
        }

        var isShopping = GameManager.Instance.GetState() == GameState.SHOPPING;
        
        if (!shopTooltip.activeSelf) 
            shopTooltip.SetActive(!isShopping);
        else
            shopTooltip.SetActive(!isShopping);

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.ChangeGameState(GameState.SHOPPING);
        }
    }
}
