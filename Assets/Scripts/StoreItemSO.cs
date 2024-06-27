using UnityEngine;

[CreateAssetMenu(fileName = "NewStoreItem", menuName = "Store/Store Item")]
public class StoreItemSO : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    [TextArea]
    public string description;
    public float price;
}
