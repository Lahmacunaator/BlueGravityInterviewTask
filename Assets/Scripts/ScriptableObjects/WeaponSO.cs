using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Store/Weapon")]
public class WeaponSO : StoreItemSO
{
    public Sprite offHandIcon;
    public int damage;
    public float range;
    public float attackSpeed;
}