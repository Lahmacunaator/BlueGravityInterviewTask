using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewOutfit", menuName = "Store/Outfit")]
    public class OutfitSO : ItemSO
    {
        public Sprite mainEquipmentSprite;
        public Sprite equipmentSpriteR;
    }
}