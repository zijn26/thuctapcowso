using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemSlot
{
    public Item itemData;
    public int curQuanity;
    public int maxQuanity = 9;
    public ItemSlot(Item data, int curQuanity , int maxQuanity = 9)
    {
        this.itemData = data;
        this.curQuanity = curQuanity;
        this.maxQuanity = maxQuanity;
    }
    public bool Isfull()
    {
        return curQuanity >= maxQuanity;
    }
    public int CountQable()
    {
        return maxQuanity - curQuanity;
    }
    public void SetMaxQuanity(int value)
    {
        maxQuanity = value;
    }
}

