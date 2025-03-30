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
    protected override void Start()
    {
        base.Start();
        listSkill.Add(new SkillData(){
            skillType = SkillType.MeleBasicSkill , dame = 10 , coolDown = 1 , range = 2 , manaCost = 0
        });
        InitCoolDown();
    }
    public void LoadCurStat()
    {
        curStat.Add(StatType.Hp , maxStat[StatType.Hp]);
        curStat.Add(StatType.Saitama , maxStat[StatType.Saitama]);
        LoadBarValue();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(UseSkill(listSkill[0]))
            {

                // Debug.Log("Use Skill " + listSkill[0].skillType);
            }
            else
            {
                // Debug.Log("false");
            }
        }
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

    protected override LayerMask GetLayerMask()
    {
        throw new System.NotImplementedException();
    }
}
