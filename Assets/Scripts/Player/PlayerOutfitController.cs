using System;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class PlayerOutfitController : MonoBehaviour
    {
        [Header("Changeable Outfits")]
        [Header("Head Parts")]
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
                    weaponMain.sprite = weapon != null ? weapon.mainHandSprite : weaponMain.sprite;
                    weaponOffhand.sprite = weapon != null ? weapon.offHandSprite : weaponOffhand.sprite;
                    break;
                case ItemType.HOOD:
                    var hoodData = item as OutfitSO;
                    hood.sprite = hoodData != null ? hoodData.mainEquipmentSprite : hood.sprite;
                    break;
                case ItemType.FACE:
                    var faceData = item as OutfitSO;
                    face.sprite = faceData != null ? faceData.mainEquipmentSprite : face.sprite;
                    break;
                case ItemType.TORSO:
                    var torsoData = item as OutfitSO;
                    torso.sprite = torsoData != null ? torsoData.mainEquipmentSprite : torso.sprite;
                    break;
                case ItemType.PELVIS:
                    var pelvisData = item as OutfitSO;
                    pelvis.sprite = pelvisData != null ? pelvisData.mainEquipmentSprite : pelvis.sprite;
                    break;
                case ItemType.SHOULDERS:
                    var shouldersData = item as OutfitSO;
                    shoulderL.sprite = shouldersData != null ? shouldersData.mainEquipmentSprite : shoulderL.sprite;
                    shoulderR.sprite = shouldersData != null ? shouldersData.equipmentSpriteR : shoulderR.sprite;
                    break;
                case ItemType.ELBOWS:
                    var elbowsData = item as OutfitSO;
                    elbowL.sprite = elbowsData != null ? elbowsData.mainEquipmentSprite : elbowL.sprite;
                    elbowR.sprite = elbowsData != null ? elbowsData.equipmentSpriteR : elbowR.sprite;
                    break;
                case ItemType.GLOVES:
                    var glovesData = item as OutfitSO;
                    handL.sprite = glovesData != null ? glovesData.mainEquipmentSprite : handL.sprite;
                    handR.sprite = glovesData != null ? glovesData.equipmentSpriteR : handR.sprite;
                    break;
                case ItemType.LEGS:
                    var legsData = item as OutfitSO;
                    legL.sprite = legsData != null ? legsData.mainEquipmentSprite : legL.sprite;
                    legR.sprite = legsData != null ? legsData.equipmentSpriteR : legR.sprite ;
                    break;
                case ItemType.SHOES:
                    var shoesData = item as OutfitSO;
                    bootL.sprite = shoesData != null ? shoesData.mainEquipmentSprite : bootL.sprite;
                    bootR.sprite = shoesData != null ? shoesData.equipmentSpriteR : bootR.sprite;
                    break;
                case ItemType.FULLSET:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
