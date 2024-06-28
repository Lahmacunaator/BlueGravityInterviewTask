using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewOutfit", menuName = "Store/Outfit")]
public class OutfitSO : ItemSO
{
    public Sprite mainEquipmentSprite;
    public Sprite equipmentSpriteR;
    public int health;
    public int defense;
}