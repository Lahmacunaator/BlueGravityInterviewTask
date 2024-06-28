using UnityEngine;

namespace ScriptableObjects
{
    public class ItemSO : ScriptableObject
    {
        public ItemType itemType;
        public Sprite icon;
        public string itemName;
        [TextArea]
        public string description;
        public int price;

        public int GetSellPrice => Mathf.FloorToInt(price / 5f * 3f);
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
}