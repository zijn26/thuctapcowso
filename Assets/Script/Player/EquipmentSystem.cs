using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class EquipmentSystem : HungMono
{
    [SerializeField] public Dictionary<ItemType, Item> listEquipment;
    [SerializeField] protected PlayerCrl playerCrl;
    public int countList;
    public event EventHandler OnEquipItemChanged;
    public event EventHandler OnUnEquipItemChanged;
 
    void Awake()
    {
        Debug.Log("hung");
        if (listEquipment == null)
        {
            listEquipment = new();
            InitQuipmentSlot();
            countList = listEquipment.Count;
        }
        else countList = listEquipment.Count; 
    }
    protected void InitQuipmentSlot()
    {
        listEquipment.Add(ItemType.Weopon, null);
        listEquipment.Add(ItemType.Amor, null);
        listEquipment.Add(ItemType.Shose, null);
        listEquipment.Add(ItemType.Hemmet, null);
    }
    public Item EquipItem(Item itemQuip)
    {
        if (itemQuip == null || listEquipment == null)
        {
            Debug.LogWarning("EquipItem : item not found");
            return null;
        }

        // Debug.Log(listEquipment.Keys);
        // foreach(var name in listEquipment.Keys) Debug.Log(name);
            Item itemOld = listEquipment[itemQuip.itemType];// comsumable item khong namt trong listEquipment

            listEquipment[itemQuip.itemType] = itemQuip;
            if (OnEquipItemChanged != null)
            {
                OnEquipItemChanged((itemOld , itemQuip), EventArgs.Empty);
            }
            if (itemOld != null)
            {
                UpdateStat(playerCrl.proceserPlayer.statSys, itemOld, false);
            }
            UpdateStat(playerCrl.proceserPlayer.statSys, itemQuip, true);
            Debug.Log("Equip " + itemQuip.nameIt);
            return itemOld;
    }
    public Item UnEquipItem(Item unItemQuip)
    {
        if (unItemQuip == null)
        {
            Debug.LogWarning("UnEquipItem : item not found");
            return null;
        }
        Item itemOld = listEquipment[unItemQuip.itemType];
        if (itemOld == null) return null;
        UpdateStat(playerCrl.proceserPlayer.statSys, itemOld, false);
        listEquipment[unItemQuip.itemType] = null;
        if (OnEquipItemChanged != null)
        {
            OnUnEquipItemChanged((unItemQuip , listEquipment[unItemQuip.itemType]), EventArgs.Empty);
        }
        return itemOld;
    }
    protected void UpdateStat(StatSys statSys, Item item, bool isAdd = true)
    {
        int mul = 1;
        if (!isAdd) mul = -1;
        if (item == null || statSys == null)
        {
            Debug.LogWarning("UpdateStat : item or statSys not found");
            return;

        }
        foreach (var statItem in item.listStatItem)
        {
            statSys.AddBonusStat(statItem.statType, mul * statItem.stat);
        }
    }
    public void UseItem(Item item)
    { 
        if (item == null)
        {
            Debug.LogWarning("UseItem : item not found");
            return;
        }
        switch (item.itemType)
        {
            case ItemType.Comsumable:
                UseComsumableItem(item);
                break;
            default:
                EquipItem(item);
                break;
        }
    }
    protected void UseComsumableItem(Item item)
    { 
        
    }
    protected override void LoadComponent()
    {
        if (playerCrl == null)
        {
            playerCrl = this.transform.GetComponentInParent<PlayerCrl>();
        }
    }
}
