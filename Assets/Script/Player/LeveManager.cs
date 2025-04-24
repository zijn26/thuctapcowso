using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
[Serializable]
public class LeveManager 
{
    [SerializeField] protected float curExp;
    [SerializeField] protected float maxExp = 100;
    [SerializeField] protected int leverPlayer;
    [SerializeField] protected float mulMaxExp = 1.2f;
    [SerializeField] protected int valuePointStats = 1;
    public int freePointStats;

    public event EventHandler OnChangedLeve;
    public event EventHandler OnChangedExp;
    public void AddExperence(int amoutExp)
    {
        this.curExp += amoutExp;
        while(curExp >= maxExp)
        {
            valuePointStats = leverPlayer % 10;
            curExp -= maxExp;
            leverPlayer ++ ;
            maxExp = maxExp + (maxExp*mulMaxExp);
            this.freePointStats ++ ;
            if(OnChangedLeve != null ) OnChangedLeve(this , EventArgs.Empty);
        }
        BarCrl.Instance.experenceBar.value = this.ValueExpBar();
        if(OnChangedExp != null) OnChangedExp(this , EventArgs.Empty);
    }
    public int GetLeve()
    {
        return leverPlayer;
    }
    public float ValueExpBar()
    {
        return curExp / maxExp;
    }
}
