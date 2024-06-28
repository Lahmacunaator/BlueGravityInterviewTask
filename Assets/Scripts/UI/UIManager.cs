using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopUI;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShopUI() => shopUI.SetActive(!shopUI.activeSelf);
}
