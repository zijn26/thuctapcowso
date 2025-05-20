using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] public List<ItemSlot> listItem = new ();

    public bool AddItem(Item item, int value)
    {
        // Debug.Log("Add Item " + item.name + " value " + value);
        ItemSlot itemSlot = GetItSlotNotFull(item);
        if (itemSlot != null)
        {
            itemSlot.maxQuanity = item.maxQuanity;
            if (value - itemSlot.CountQable() <= 0)
            {
                itemSlot.curQuanity += value;
                return true;
            }
            else
            {
                value -= itemSlot.CountQable();
                itemSlot.curQuanity = item.maxQuanity;
            }
        }
        while (value > 0)
        {
            if (value >= item.maxQuanity)
            {
                listItem.Add( new ItemSlot(item, item.maxQuanity , item.maxQuanity));
            }
            else
            {
                listItem.Add(new ItemSlot(item, value , item.maxQuanity));
            }
            value -= item.maxQuanity;
        }
        return true;
    }
    public bool RemoveItem(Item item, int value)
    {
        ItemSlot itemSlot = listItem.Find((it) =>{
            if (it.itemData.idItem == item.idItem) return true;
            return false;
        });
        if (itemSlot == null)
        { 
            Debug.LogWarning("RemoveItem : item not found");
            return false;
        }

        if(itemSlot.curQuanity - value <= 0) listItem.Remove(itemSlot);
        else itemSlot.curQuanity -= value;
        return true;
    }
    protected ItemSlot GetItSlotNotFull(Item item)
    {
        return listItem.Find((itSlot) =>
        {
            if (itSlot.itemData.idItem == item.idItem && !itSlot.Isfull())
                return true;
            return false;
        });
    }
}
