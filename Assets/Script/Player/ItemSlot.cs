using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemSlot
{
    public Item itemData;
    public int curQuanity;
    public static int maxQuanity = 9;
    public ItemSlot(Item data,  int curQuanity)
    {
        this.itemData = data;
        this.curQuanity = curQuanity;
    }
    public bool Isfull()
    {
        return curQuanity >= maxQuanity;
    }
    public int CountQable()
    {
        return maxQuanity - curQuanity;
    }
}

