using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Item / Create New Item SC")]
public class ItemSc : ScriptableObject
{
    public float hpItem ;
    public float attackItem;
    public float speedItem;
    public float durability;
    public String describe;
    public ItemType itemType;
    
}
public enum ItemType {
    weapons = 1,
    amor = 2,
}
