using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum SkillType
{
    MeleBasicSkill = 1,
    RangeBasicSkill = 2, 
    MagicSkill = 3,
    HealSkill = 4,
    BuffSkill = 5,
    DebuffSkill = 6,
    AOESkill = 7,
}
[Serializable]
public class SkillData
{
    public SkillType skillType;
    public float dame;
    public float coolDown;
    public float range;
    public float manaCost;
}
public abstract class CombatEnity : HungMono  
{
    [SerializeField] protected LayerMask seftlayerMask;
    // lop co so dung chung cho player va enemy
    public Dictionary<StatType , float> curStat = new();
    public Dictionary<StatType , float> maxStat = new   (); 

    public Dictionary<SkillType , float > curCoolDown = new() ; // load skill cooldown tu save
    public List<SkillData> listSkill = new();
    public event EventHandler OnTakenDamage;
    public event EventHandler Ondie;
    protected bool isCountDown;
    void Awake()
    {
        if(curStat == null)
        {
            curStat = new Dictionary<StatType, float>();
        }
        if(maxStat == null)
        {
            maxStat = new Dictionary<StatType, float>();
        }
        if(curCoolDown == null)
        {
            curCoolDown = new Dictionary<SkillType, float>();
        }
        if(listSkill == null)
        {
            listSkill = new List<SkillData>();
        }
    }
    protected void FixedUpdate()
    {
        UpdateCoolDown();
    }
    
    public void TakeDamage(float dame)
    {
        Debug.Log("Take Damage" + dame ) ;
        Debug.Log("Current Hp" + this.curStat[StatType.Hp]);
        curStat[StatType.Hp] -= dame;
        if(OnTakenDamage != null) OnTakenDamage(this , EventArgs.Empty);

        if(this.curStat[StatType.Hp] <= 0)
        {
            Debug.Log("Die");
            if(Ondie != null) Ondie(this , EventArgs.Empty);
        }
    }
    public float BasicDame(CombatEnity target )
    {
        float dame = maxStat[StatType.Attack];
        target.TakeDamage(dame);
        return dame;
    }
    public bool UseSkill(SkillData skillData)
    {
        Collider2D collider2D = Physics2D.Raycast(transform.position ,this.transform.right , skillData.range ,seftlayerMask).collider;
        Debug.DrawRay(transform.position , this.transform.right * skillData.range , Color.red);
        if(collider2D == null) return false;
        if(collider2D.gameObject == this.gameObject) return false;
        // Debug.Log(collider2D.gameObject.name);

        CombatEnity target = collider2D.GetComponent<CombatEnity>();
        if(target == null) return false;
        // Debug.Log("target " + target.gameObject.name);

        if(!CanUseSkill(skillData.skillType))
        {
            return false;
        } 
        
        // Debug.Log("Use Skill");
        CoolDownSkill(skillData);
        
        switch (skillData.skillType)
        {
            case SkillType.MeleBasicSkill:
                BasicDame(target);
                break;
            case SkillType.RangeBasicSkill:
                    
                break;
            case SkillType.MagicSkill:
                    
                break;
            case SkillType.HealSkill:
                    
                break;
            case SkillType.BuffSkill:
                    
                break;
            case SkillType.DebuffSkill:
                    
                break;
            case SkillType.AOESkill:
                    
                break;
            default:
                break;
        }
        return true;
    }
    protected void InitCoolDown()
    {
        foreach (var item in listSkill)
        {
            curCoolDown.Add(item.skillType , 0);
            // Debug.Log(item.skillType + " " + item.coolDown);
        }
        // Debug.Log("coutn " + curCoolDown.Count);
    }
    protected void UpdateCoolDown()
    {
        if(curCoolDown.Count > 0 )
        foreach( var i in listSkill)
        {
            if(curCoolDown[i.skillType] <= 0) continue;
            curCoolDown[i.skillType] -= Time.deltaTime;
        }
    }
    protected void CoolDownSkill(SkillData data)
    {
        curCoolDown[data.skillType] = data.coolDown;
    }
    protected bool CanUseSkill(SkillType skillType)
    {
        // Debug.Log("skill is " + curCoolDown.Count);
        return curCoolDown[skillType] <= 0;
    }
    protected override void LoadComponent()
    {
        // this.LoadMaxStat();
        // this.LoadCurStat();
    }
    protected abstract LayerMask GetLayerMask();
    // protected abstract void LoadCurStat();
    // protected abstract void LoadMaxStat();
}
