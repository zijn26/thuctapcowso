using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine; 
public class ProceserPlayer :  HungMono 
{
    [SerializeField] public StatSys statSys;
    [SerializeField] protected PlayerInfoSC infoSC;
    [SerializeField] public LeveManager leveManager;
    [SerializeField] public CombatPlayer combatPlayer;
    // public Dictionary<StatType, float> curStat = new ();
    void Awake()
    {
        if(statSys == null)
        {
            statSys = new StatSys();
        }
        if(leveManager == null)
        {
            leveManager = new LeveManager();
        }
       
    }
   
    protected override void LoadComponent()
    {
        this.LoadScStat();
        this.LoadStatFormSave();
        this.LoadCombatStat();
        combatPlayer.OnTakenDamage += TakenDamageHandle;// xu li khi nhan dame
        statSys.OnChangedBaseStat += HandleChange; 
        statSys.OnChangBonusStat += HandleChange;
    }
    protected void LoadScStat()
    {
        if(infoSC == null)
        {
        this.infoSC = Resources.Load<PlayerInfoSC>("Player1");
        }
    }
    protected void LoadStatFormSave()
    {
        // dung de load stat tu save
        statSys.AddStatInfo(StatType.Hp , infoSC.baseHp , 0);
        statSys.AddStatInfo(StatType.Attack , infoSC.baseAttack , 0);
        statSys.AddStatInfo(StatType.Speed , infoSC.baseSpeed , 0);
        statSys.AddStatInfo(StatType.Saitama , infoSC.baseSaitama , 0);
        combatPlayer.LoadMaxStat();
        combatPlayer.LoadCurStat();
    }
    protected void HandleChange(object obj , EventArgs args)
    {
        foreach (var item in statSys.ListStat)
        {
            this.combatPlayer.maxStat[item.statType] = (item.bonusStat + item.baseStat);
        }
        Debug.Log("CHang Stat");
        BarCrl.Instance.SetValueHpBar(combatPlayer.HpPercent());
        BarCrl.Instance.SetSaitamaBar(combatPlayer.SaitamaPercent());
    }
    protected void TakenDamageHandle(object obj , EventArgs args)
    {
        BarCrl.Instance.SetValueHpBar(combatPlayer.HpPercent());
    }
    protected void SetBarValue()
    {
        BarCrl.Instance.SetExperentceBar(leveManager.ValueExpBar());
    }
    protected void LoadCombatStat()
    {
        if(combatPlayer == null)
        {
            combatPlayer = this.transform.GetComponentInChildren<CombatPlayer>();
        }
    }
    // protected void LoadAndInitCurStat()
    // {
    //     curStat.Add(StatType.Hp , statSys.GetStatNumber(StatType.Hp));
    //     curStat.Add(StatType.Attack , statSys.GetStatNumber(StatType.Attack));
    //     curStat.Add(StatType.Speed , statSys.GetStatNumber(StatType.Speed));
    //     curStat.Add(StatType.Saitama , statSys.GetStatNumber(StatType.Saitama));
    //     SetBarValue();
    // }
}
