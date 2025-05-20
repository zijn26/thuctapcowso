using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatSys 
{
    [SerializeField] private List<StatInfo> listStat = new ();
    public List<StatInfo> ListStat => listStat;
    public event EventHandler OnChangedBaseStat;
    public event EventHandler OnChangBonusStat;
    public void AddStatInfo(StatType stattype , float basestat , float bonusstat)
    {
        listStat.Add( new StatInfo(stattype , basestat , bonusstat));
    }
    // public void AddStatNumber( StatType statType , float number)
    // {
    //     var statinfo = listStat.Find( x => x.statType == statType);
    //     statinfo.baseStat += number;
    // }
    public StatInfo GetStatInfo(StatType statType)
    {
        return listStat.Find( x => x.statType == statType);
    }
    public void AddBaseStat(StatType statType , float value)
    {
        var statinfo = listStat.Find(x => x.statType == statType);
        statinfo.baseStat += value;
        if(OnChangedBaseStat != null) OnChangedBaseStat(statType , EventArgs.Empty);
    }
    public void AddBonusStat(StatType statType , float value)
    {
        var statinfo = listStat.Find(x => x.statType == statType);
        statinfo.bonusStat += value;
        if(OnChangBonusStat != null) OnChangBonusStat(statType , EventArgs.Empty);
    }
    public float GetStatNumber(StatType statType)
    {
        var statinfo = listStat.Find( x => x.statType == statType);

        return statinfo.baseStat + statinfo.bonusStat;
    }
}
[Serializable]
public enum StatType
{
    Hp = 1,
    Attack = 2,
    Speed = 3,
    Saitama = 4,
}
[Serializable]
public class StatInfo
{
    public StatInfo(StatType statType , float baseStat , float bonusStat)
    {
        this.statType = statType;
        this.baseStat = baseStat;
        this.bonusStat = bonusStat;
    }
    public StatType statType;
    public float baseStat;
    public float bonusStat;
}