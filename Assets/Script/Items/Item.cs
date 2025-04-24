using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Item/ItemSc")]
[Serializable]
public class Item : ScriptableObject
{
    public int idItem;
    public Sprite iconIt;
    public string nameIt;
    public string description;
    public ItemType itemType;
    public float pointInIt;
    public Item(int idItem , Sprite sprite , string nameIt , string description  , ItemType itemType, float pointInIt)
    {
        this.idItem = idItem;
        this.iconIt = sprite;
        this.nameIt = nameIt;
        this.description = description;
        this.itemType = itemType;
        this.pointInIt = pointInIt;
    }
     public Item(Item item)
    {
        this.idItem = item.idItem;
        this.iconIt = item.iconIt;
        this.nameIt = item.nameIt;
        this.description = item.description;
        this.itemType = item.itemType;
        this.pointInIt = item.pointInIt;
    }
}
public enum ItemType
{
    Weopon = 0,
    Amor = 1,
    Shose = 2,
    Hemmor = 3,

}
