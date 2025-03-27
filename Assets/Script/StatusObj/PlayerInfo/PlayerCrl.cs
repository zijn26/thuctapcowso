using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class PlayerCrl : HungMono
{
    public static PlayerCrl Instance ;
    public ProceserPlayer proceserPlayer;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            proceserPlayer.leveManager.AddExperence(10);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            proceserPlayer.combatPlayer.TakeDamage(10);
            // BarCrl.Instance.SetValueHpBar(proceserPlayer.statSys.GetStatNumber(StatType.Hp));
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            proceserPlayer.statSys.AddBaseStat(StatType.Hp , 10);
        }
    }
    protected override void LoadComponent()
    {
        Debug.Log("Done Load Player Crl");
        LoadProceserPlayer();
    }
    protected void LoadProceserPlayer()
    {
        if(proceserPlayer == null)
        {
            this.proceserPlayer = this.transform.GetComponentInChildren<ProceserPlayer>();
        }
    }
    // protected void LoadInfoToBar()
    // {
    //     // BarCrl.Instance.SetValueHpBar(proceserPlayer.statSys.GetStatNumber(StatType.Hp));
    //     // BarCrl.Instance.SetSaitamaBar(proceserPlayer.statSys.GetStatNumber(StatType.Saitama));
    //     // BarCrl.Instance.SetExperentceBar(proceserPlayer.leveManager.ValueExpBar());
    // }
    // protected void LoadLeveManager()
    // {
    //     if(leveManager == null )
    //     {
    //         this.leveManager = this.transform.GetComponentInChildren<LeveManager>();
    //     }
    // }
}
