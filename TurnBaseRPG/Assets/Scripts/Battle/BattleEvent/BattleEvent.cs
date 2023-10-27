using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvent_BattleUnitApplyDamage : BattleEventBase
{
    public const string EventName = "BattleEvent_BattleUnitApplyDamage";
    public BattleUnit Unit;
    public int BeforeDamagedHP;
    public int AfterDamagedHP;
    public int DamagedHP;
    //TODO:可能再判断暴击之类的

    public static void Trigger(BattleUnit unit,int beforHP,int afterHP,int damage)
    {
        EventManager.Instance.TriggerEvent(EventName,new BattleEvent_BattleUnitApplyDamage(){Unit = unit,BeforeDamagedHP = beforHP,AfterDamagedHP = afterHP,DamagedHP = damage});
    }
}

public class BattleEvent_BattleUnitApplyHeal : BattleEventBase
{
    public const string EventName = "BattleEvent_BattleUnitApplyHeal";
    public BattleUnit Unit;
    public int BeforeHealedHP;
    public int AfterHealedHP;
    public int HealedHP;
}


