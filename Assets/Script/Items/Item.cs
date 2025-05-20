using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item/ItemSc")]
[Serializable]
public class Item : ScriptableObject
{
    public int idItem;
    public Sprite iconIt;
    public string nameIt;
    public string description;
    public int maxQuanity;
    public ItemType itemType;
    public List<StatItem> listStatItem = new();
    public List<EffectType> listEffectType = new();
    public Item(int idItem, Sprite sprite, string nameIt, string description, ItemType itemType, float pointInIt)
    {
        this.idItem = idItem;
        this.iconIt = sprite;
        this.nameIt = nameIt;
        this.description = description;
        this.itemType = itemType;
    }
    public Item(Item item)
    {
        this.idItem = item.idItem;
        this.iconIt = item.iconIt;
        this.nameIt = item.nameIt;
        this.description = item.description;
        this.itemType = item.itemType;
    }
    void OnValidate()
    {
        switch (itemType)
        {
            case ItemType.Weopon:
                maxQuanity = 1;
                break;
            case ItemType.Amor:
                maxQuanity = 1;
                break;
            case ItemType.Shose:
                maxQuanity = 1;
                break;
            case ItemType.Hemmet:
                maxQuanity = 1;
                break;
            case ItemType.Comsumable:
                maxQuanity = 10;
                break;
            default:
                maxQuanity = 10;
                break;
        }
    }
}
public enum ItemType
{
    Weopon = 0,
    Amor = 1,
    Shose = 2,
    Hemmet = 3,
    Comsumable = 4,
}
[Serializable]
public class StatItem
{
    public StatType statType;
    public float stat;
}
public class EffectData
{ 
    public EffectType effectType;
    public int value;
    public float timeEffect;
    public EffectData(EffectType effectType, int value, float timeEffect)
    {
        this.effectType = effectType;
        this.value = value;
        this.timeEffect = timeEffect;
    }
}
