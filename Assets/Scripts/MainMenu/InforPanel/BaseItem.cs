using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType{
    Helmet, // Nón
    Chest,
    Gloves,
    Weapon,
    Ring,
    Necklace,
}
[System.Serializable]
public class BaseItem 
{
    public string itemName;
    public Sprite itemImage;
    [Space]
    public int AttackBonus;
    public int HealthBonus;
    [Space]
    public ItemType ItemType;
    public int Price;
}
