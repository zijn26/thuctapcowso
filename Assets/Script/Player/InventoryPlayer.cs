using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [SerializeField] public List<ItemSlot> listItem = new ();

    public bool AddItem(Item item, int value)
    {
        ItemSlot itemSlot = GetItSlot(item);
        if (itemSlot != null)
        {
            if (value - itemSlot.CountQable() <= 0)
            {
                itemSlot.curQuanity += value;
                value = 0;
                return true;
            }
            else
            {
                value -= itemSlot.CountQable();
                itemSlot.curQuanity = ItemSlot.maxQuanity;
            }
        }
        while (value <= 0)
        {
            if (value >= ItemSlot.maxQuanity)
            {
                listItem.Add(new ItemSlot(item, ItemSlot.maxQuanity));
            }
            else
            {
                listItem.Add(new ItemSlot(item, value));
            }
            value -= ItemSlot.maxQuanity;
        }
        return true;
    }
    protected ItemSlot GetItSlot(Item item)
    {
        return listItem.Find((itSlot) =>
        {
            if (itSlot.itemData.idItem == item.idItem && !itSlot.Isfull())
                return true;
            return false;
        });
    }
}
