using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMonster : CombatEnity
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        InitSkill();
        InitStat();
        InitCurStat();
    }
    protected void InitSkill()
    {
        listSkill.Add(new SkillData(){
            skillType = SkillType.MeleBasicSkill , dame = 10 , coolDown = 1 , range = 2 , manaCost = 0
        });
    }
    protected void InitStat()
    {
        maxStat.Add(StatType.Hp , 100);
        
    }
    protected void InitCurStat()
    {
        curStat.Add(StatType.Hp , maxStat[StatType.Hp]);
    }

    protected override LayerMask GetLayerMask()
    {
        return LayerMask.GetMask("Player");
    }
}
