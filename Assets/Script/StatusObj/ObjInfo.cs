using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjInfo : HungMono
{
    [Header("Object Info")]
    [SerializeField] protected float curHp;
    [SerializeField] protected float baseHp;
    [SerializeField] protected float maxHp;
    
    public float baseAttack ;
    public float maxAttack;

    public float baseSpeed;
    public float maxSpeed;

    public virtual void IncCurHp(float value)
    {
        this.curHp += value;
        ActionOnChangedHp();
    }
    public virtual void IncBaseHp(float value)
    {
        this.baseHp += value;
    }
    public virtual void IncMaxHp(float value)
    {
        this.maxHp += value;
        ActionOnChangedHp();
    }

    public virtual void SetCurHp(float value)
    {
        this.curHp = value;
        ActionOnChangedHp();
    }
    public virtual void SetBaseHp(float value)
    {
        this.baseHp = value;
    }
    public virtual void SetMaxHp(float value)
    {
        this.maxHp = value;
        ActionOnChangedHp();
    }
    public bool IsDead()
    {
        return this.curHp <= 0;
    }
    public abstract void ActionOnChangedHp() ;
}
