using System;
using UnityEngine;

public class PlayerOutfitController : MonoBehaviour
{
    [Header("Changeable Outfits")]
    [Header("Head Parts")]
    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer face;
    [SerializeField] private SpriteRenderer hood;
    
    [Header("Arms And Hands")]
    [SerializeField] private SpriteRenderer weaponMain;
    [SerializeField] private SpriteRenderer weaponOffhand;
    [SerializeField] private SpriteRenderer handL;
    [SerializeField] private SpriteRenderer handR;
    [SerializeField] private SpriteRenderer elbowL;
    [SerializeField] private SpriteRenderer elbowR;
    [SerializeField] private SpriteRenderer shoulderL;
    [SerializeField] private SpriteRenderer shoulderR;
    
    [Header("Body")]
    [SerializeField] private SpriteRenderer torso;
    [SerializeField] private SpriteRenderer pelvis;
    [SerializeField] private SpriteRenderer legL;
    [SerializeField] private SpriteRenderer legR;
    [SerializeField] private SpriteRenderer bootL;
    [SerializeField] private SpriteRenderer bootR;

    public void ApplyEquipItemVisuals(ItemSO item)
    {
        switch (item.itemType)
        {
            case ItemType.WEAPON:
                var weapon = item as WeaponSO;
                weaponMain.sprite = weapon.mainHandSprite;
                weaponOffhand.sprite = weapon.offHandSprite;
                break;
            case ItemType.HOOD:
                var hood = item as OutfitSO;
                this.hood.sprite = hood.mainEquipmentSprite;
                break;
            case ItemType.FACE:
                break;
            case ItemType.TORSO:
                var torso = item as OutfitSO;
                this.torso.sprite = torso.mainEquipmentSprite;
                break;
            case ItemType.PELVIS:
                var pelvis = item as OutfitSO;
                this.pelvis.sprite = pelvis.mainEquipmentSprite;
                break;
            case ItemType.SHOULDERS:
                var shoulders = item as OutfitSO;
                shoulderL.sprite = shoulders.mainEquipmentSprite;
                shoulderR.sprite = shoulders.equipmentSpriteR;
                break;
            case ItemType.ELBOWS:
                var elbows = item as OutfitSO;
                elbowL.sprite = elbows.mainEquipmentSprite;
                elbowR.sprite = elbows.equipmentSpriteR;
                break;
            case ItemType.GLOVES:
                var gloves = item as OutfitSO;
                handL.sprite = gloves.mainEquipmentSprite;
                handR.sprite = gloves.equipmentSpriteR;
                break;
            case ItemType.LEGS:
                var legs = item as OutfitSO;
                legL.sprite = legs.mainEquipmentSprite;
                legR.sprite = legs.equipmentSpriteR;
                break;
            case ItemType.SHOES:
                var shoes = item as OutfitSO;
                bootL.sprite = shoes.mainEquipmentSprite;
                bootR.sprite = shoes.equipmentSpriteR;
                break;
            case ItemType.FULLSET:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
