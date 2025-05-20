using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCrl : HungMono
{
    public MonsterAttack monsterAttack;
    public MonsterBar monsterBar;
    public MonsterMove monsterMove;
    public MonsterInventory monsterIvtory;

    protected override void LoadComponent()
    {   
        LoadMonsterAttack();
        LoadMonsterBar();
        monsterAttack.combatMonster.OnTakenDamage += TakenDamageHandle; // xu li khi nhan dame
        monsterAttack.combatMonster.Ondie += DieHandle;
        LoadMonsterMove();
        LoadMonterInventory();
    }
    protected void TakenDamageHandle(object obj, EventArgs args)
    {
        if (monsterBar == null) return;
        monsterBar.SetBar(monsterAttack.combatMonster.GetPercentHp());
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        monsterIvtory.DropItem();
    }
    protected void DieHandle(object obj, EventArgs args)
    {
        monsterIvtory.DropItem();
        MonsterPool.Instance.DeSpawnObj(this.gameObject.transform);
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
    protected void LoadMonterInventory()
    {
        if(this.monsterIvtory != null) return;
        this.monsterIvtory = this.gameObject.GetComponentInChildren<MonsterInventory>();
    }
}
