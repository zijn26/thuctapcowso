using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class MonsterMove : BaseMove
{
    [SerializeField] protected CombatMonster combatMonster;
    [SerializeField] protected MonsterAuto autoSC;
    [SerializeField] protected Vector3 originPos;
    [SerializeField] protected Transform target;
    [SerializeField] protected float distanceToTarget;
    [SerializeField] protected float distanceToOriginPos;
    [SerializeField] public bool detectPlayer;
    protected void Enable()
    {
        this.originPos = this.transform.position;
    }
    protected override float GetMaxSpeed()
    {
        return combatMonster.maxStat[StatType.Speed];

    }

    protected override void LoadDirMove()
    {
        this.distanceToTarget = Vector3.Distance(this.transform.position, target.position); 
        this.distanceToOriginPos = Vector3.Distance(this.transform.position, originPos);  
        if(distanceToTarget < autoSC.distanceToChaise && this.distanceToOriginPos < autoSC.maxDistanceFromOriginPos)
        {
            this.detectPlayer = true;
            this.dirMove.x = (this.target.position - this.transform.position).normalized.x;
        }else detectPlayer = false;
        
        if( distanceToOriginPos <= autoSC.rangeStand && distanceToTarget > autoSC.distanceToChaise) this.dirMove.x = 0;
        else if(this.distanceToOriginPos > autoSC.maxDistanceFromOriginPos)
        {
            this.dirMove.x = (this.originPos - this.transform.position).normalized.x;
        }
    }

    protected override void LoadGroundCheck()
    {
        this.centerGCheck = this.transform.GetChild(2);
    }

    protected override void LoadMoveSC()
    {
        if(moveSC == null)
        {
            moveSC = Resources.Load<MoveSSC>("Monster");
        }
        if(autoSC == null)
        {
            autoSC = Resources.Load<MonsterAuto>("MonsterNomal");
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if(combatMonster == null)
        {    
            combatMonster = GetComponent<CombatMonster>();
        }
        
        this.originPos = this.transform.position;
        this.target = GameObject.Find("Player").transform;
    }
    
}
