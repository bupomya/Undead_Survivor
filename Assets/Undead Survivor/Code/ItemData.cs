using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/itemData ")]

public class ItemData : ScriptableObject
{
    public enum ItemType
    {
        Melee0, // ��
        //Melee1, // ����â
        //Melee2, // ��
        Gun0, // ����
        //Gun1, // ����
        //Gun2, // ����
        Glove, // �尩
        Shoe, // �Ź�
        Heal // ����?
    }

    [Header("# Main Infomation")]
    public ItemType itemType;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc; // ����
    public Sprite itemIcon;

    [Header("# Level Data")]
    public float baseDamege;
    public int baseCount; // ���� : ���� / ���Ÿ� : �����
    public float[] damages; // ���� ������
    public int[] counts;

    [Header("# Weapon")]
    public GameObject projectile;
    public Sprite hand;

}
