using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EffectMana : MonoBehaviour
{
    /// <summary>
    /// tạm thời dừng phát triển để ưu tiên các chức năng khác do chức năng này có 
    /// quá nhiều thứ phức tạp chưa giải quyết được.
    /// </summary>
    public static EffectMana instance;
    public event EventHandler OnEffectChange;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UseEffect(EffectData effectData)
    {
        switch (effectData.effectType)
        {
            case EffectType.UpHp:
                StartCoroutine(ChangeCurStat(effectData.value, StatType.Hp, effectData.timeEffect,
                    PlayerCrl.Instance.proceserPlayer.combatPlayer, true
                ));
                break;
            case EffectType.UpMp:
                break;
            case EffectType.UpAttack:
                break;
            case EffectType.UpSaitama:
                break;
            case EffectType.upSpeed:
                break;
            case EffectType.DeUpHp:
                break;
            case EffectType.DeUpMp:
                break;
            case EffectType.DeUpAttack:
                break;
            case EffectType.DeUpSaitama:
                break;
            case EffectType.DeUpSpeed:
                break;

        }
    }
    protected IEnumerator ChangeCurStat(float totalvalue, StatType statType, float timeEffect , CombatEnity enity , bool isUp)
    {

        float startTime = Time.time;
        float endTime = startTime + timeEffect;
        float mul = 1f;
        float valuePerFm = totalvalue / timeEffect;
        mul = isUp ? 1 : -1;
        while (startTime <= endTime)
        {
            startTime += Time.deltaTime;
            enity.curStat[statType] = Mathf.Min(enity.curStat[statType] + (mul * valuePerFm * Time.deltaTime), enity.maxStat[statType]);
            yield return null;
        }
    }

}
public enum EffectType
{
    UpHp = 0,
    UpMp = 1,
    UpAttack = 2,
    UpSaitama = 3,
    upSpeed = 8,
    DeUpHp = 4,
    DeUpMp = 5,
    DeUpAttack = 6,
    DeUpSaitama = 7,
    DeUpSpeed = 9,
}
