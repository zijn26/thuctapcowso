using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSystem : ObjInfo
{
    [Header("StatsSystem Info")]
    [SerializeField] public float curSaitama;
    [SerializeField] public float baseSaitama;
    [SerializeField] public float maxSaitama;
    [SerializeField] public float statPointFree;
    [SerializeField] protected PlayerInfoSC infoSC;
    [SerializeField] protected static StatsSystem instance;

    public static StatsSystem Instance => instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else Destroy(gameObject);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IncCurHp(-6);
            // PlayerCrl.Instance.leveManager.AddExperence(100);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            IncCurHp(3);
        }
    }
    protected override void LoadComponent()
    {
        Debug.Log("Done load info Player");

        this.infoSC = Resources.Load<PlayerInfoSC>("Player1");
        LoadSCtoPlyerInfo();
    }
    protected override void Start()
    {
        base.Start();
        SetCurHp(this.maxHp);
        SetCurStaitama(this.maxSaitama);
    }
    protected void LoadSCtoPlyerInfo()
    {
        SetBaseHp(this.infoSC.baseHp);
        this.baseAttack = infoSC.baseAttack;
        this.baseSaitama = infoSC.baseSaitama;
        this.baseSpeed = infoSC.baseSpeed;

        this.maxHp = this.baseHp;
        this.maxAttack = this.baseAttack;
        this.maxSaitama = this.baseSaitama;
        this.maxSpeed = this.baseSpeed;
    }
    public override void ActionOnChangedHp()
    {
        BarCrl.Instance.SetValueHpBar(this.curHp / this.maxHp);
    }
    public void SetCurStaitama(float saitama)
    {
        this.curSaitama = saitama;
        ActionOnChangedSaitama();
    }
    public void IncCurSaitama(float value)
    {
        this.curSaitama += value;
        ActionOnChangedSaitama();
    }
    public virtual void ActionOnChangedSaitama()
    {
        BarCrl.Instance.SetSaitamaBar(this.curSaitama / this.maxSaitama);
    }
    public bool EquitItem()
    {
        return false;
    }
}
