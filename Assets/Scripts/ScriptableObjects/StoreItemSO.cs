using UnityEngine;

public class StoreItemSO : ScriptableObject
{
    public StoreItemType StoreItemType;
    public Sprite icon;
    public string itemName;
    [TextArea]
    public string description;
    public float price;
}

public enum StoreItemType
{
    WEAPON,
    HEAD,
    FACE,
    TORSO,
    PELVIS,
    SHOULDERS,
    ELBOWS,
    GLOVES,
    LEGS,
    SHOES
}