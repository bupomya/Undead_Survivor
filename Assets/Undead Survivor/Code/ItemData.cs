using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/itemData ")]

public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Melee0, // »ğ
        //Melee1, // »ïÁöÃ¢
        //Melee2, // ³´
        Gun0, // ¿±ÃÑ
        //Gun1, // ¼ÒÃÑ
        //Gun2, // ¼¦°Ç
        Glove, // Àå°©
        Shoe, // ½Å¹ß
        Heal // À½·á?
    }

    [Header("# Main Infomation")]
    public ItemType itemType;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc; // ¼³¸í
    public Sprite itemIcon;

    [Header("# Level Data")]
    public float baseDamege;
    public int baseCount; // ±ÙÁ¢ : °³¼ö / ¿ø°Å¸® : °üÅë¼ö
    public float[] damages; // ·¦´ç µ¥¹ÌÁö
    public int[] counts;

    [Header("# Weapon")]
    public GameObject projectile;
    public Sprite hand;

}
