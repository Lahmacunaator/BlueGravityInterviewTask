using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Store/Weapon")]
public class WeaponSO : ItemSO
{
    public Sprite mainHandSprite;
    public Sprite offHandSprite;
    public int damage;
    public float attackSpeed;
}