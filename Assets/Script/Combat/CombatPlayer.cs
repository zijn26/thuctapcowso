using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : CombatEnity
{
    // hai method loadmaxstat va loadcurstat duoc dung de load gia tri maxstat cua player
    // tu statSys va load gia tri curstat cua player tu maxstat luc moi khoi tao game
    // trong qua trinh choi tang giam stat va hp se duoc tinh toan o processerPlayer
    public void LoadMaxStat()
    {
        foreach (var item in PlayerCrl.Instance.proceserPlayer.statSys.ListStat)
        {
            maxStat.Add(item.statType , item.bonusStat + item.baseStat);
        }
    }
    
    public void LoadCurStat()
    {
        curStat.Add(StatType.Hp , maxStat[StatType.Hp]);
        curStat.Add(StatType.Saitama , maxStat[StatType.Saitama]);
        LoadBarValue();
    }
    protected void LoadBarValue()
    {
        BarCrl.Instance.SetValueHpBar(HpPercent());
        BarCrl.Instance.SetSaitamaBar(SaitamaPercent());
    }
    public float HpPercent()
    {
        return curStat[StatType.Hp] / maxStat[  StatType.Hp];
    }
    public float SaitamaPercent()
    {
        return curStat[StatType.Saitama] / maxStat[StatType.Saitama];
    }
}
