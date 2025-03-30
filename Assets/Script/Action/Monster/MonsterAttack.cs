using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterAttack : HungMono
{
    [SerializeField] public CombatMonster combatMonster;
    [SerializeField] public MonsterCrl monsterCrl;
    protected void AutomationAttack()
    {
        combatMonster.UseSkill(combatMonster.listSkill[0]);
    }
    protected override void LoadComponent()
    {
        LoadCombatMonster();
        LoadMonsterCrl();
    }
    void Update()
    {
        if(this.monsterCrl.monsterMove.detectPlayer)
        {
            AutomationAttack();
        }
    }
    protected void LoadCombatMonster()
    {
        if(combatMonster != null) return;
        combatMonster = this.transform.GetComponentInParent<CombatMonster>();
    }
    protected void LoadMonsterCrl()
    {
        if(monsterCrl != null) return;
        monsterCrl = this.transform.GetComponentInParent<MonsterCrl>();
    }
}
