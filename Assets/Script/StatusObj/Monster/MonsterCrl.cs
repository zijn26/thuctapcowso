using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCrl : HungMono
{
    public MonsterAttack monsterAttack;
    public MonsterBar monsterBar;
    public MonsterMove monsterMove;

    protected override void LoadComponent()
    {   
        LoadMonsterAttack();
        LoadMonsterBar();
        monsterAttack.combatMonster.OnTakenDamage += TakenDamageHandle; // xu li khi nhan dame
        LoadMonsterMove();
    }
    protected void TakenDamageHandle(object obj, EventArgs args)
    {
        if (monsterBar == null) return;
        monsterBar.SetBar(monsterAttack.combatMonster.GetPercentHp());
    }
    protected void LoadMonsterBar()
    {
        if(monsterBar != null) return;
        monsterBar = this.gameObject.GetComponentInChildren<MonsterBar>();
    }
    protected void LoadMonsterAttack()
    {
        if(monsterAttack != null) return;
        monsterAttack = this.gameObject.GetComponentInChildren<MonsterAttack>();
    }
    protected void LoadMonsterMove()
    {
        if(this.monsterMove != null) return;
        this.monsterMove = this.gameObject.GetComponent<MonsterMove>();
    }
}
