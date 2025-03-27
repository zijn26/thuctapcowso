using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillType
{
    
}
public abstract class CombatEnity : HungMono  
{
    // lop co so dung chung cho player va enemy
    public Dictionary<StatType , float> curStat ;
    public Dictionary<StatType , float> maxStat ; 

    public event EventHandler OnTakenDamage;
    public event EventHandler Ondie;
    void Awake()
    {
        if(curStat == null)
        {
            curStat = new Dictionary<StatType, float>();
        }
        if(maxStat == null)
        {
            maxStat = new Dictionary<StatType, float>();
        }
    }
    public void TakeDamage(float dame)
    {
        Debug.Log("Take Damage" + dame);
        curStat[StatType.Hp] -= dame;
        if(OnTakenDamage != null) OnTakenDamage(this , EventArgs.Empty);

        if(this.curStat[StatType.Hp] <= 0)
        {
            Debug.Log("Die");
            if(Ondie != null) Ondie(this , EventArgs.Empty);
        }
    }
    public float BasicDame(CombatEnity target )
    {
        float dame = curStat[StatType.Attack];
        target.TakeDamage(dame);
        return dame;
    }
    protected override void LoadComponent()
    {
        // this.LoadMaxStat();
        // this.LoadCurStat();
    }
    // protected abstract void LoadCurStat();
    // protected abstract void LoadMaxStat();
}
