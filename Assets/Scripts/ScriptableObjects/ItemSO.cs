using UnityEngine;
using UnityEngine.Serialization;

public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public Sprite icon;
    public string itemName;
    [TextArea]
    public string description;
    public int price;

    public int GetSellPrice => Mathf.FloorToInt(price / 5 * 3);
}

public enum ItemType
{
    WEAPON,
    HOOD,
    FACE,
    TORSO,
    PELVIS,
    SHOULDERS,
    ELBOWS,
    GLOVES,
    LEGS,
    SHOES,
    FULLSET
}