using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Store/Weapon")]
    public class WeaponSO : ItemSO
    {
        public Sprite mainHandSprite;
        public Sprite offHandSprite;
    }
}