using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class SkillActionBehaviorDetail 
{
    public enum BehaviorType {
        Damage,
        Heal,
        AddBuff,
        RemoveBuff
    }

    public BehaviorType Type;

    public float Value;

    public BattleUnit TargetUnit;

    public float BeforeDamageHP;

    public float AfterDamageHP;

    public float BeforHealHP;

    public float AfterHealHP;
}

public static class SkillBehaviorDetailHelper {
    public static SkillActionBehaviorDetail.BehaviorType ToBehaviorType(this SkillActionType type) {
        switch (type) {
            case SkillActionType.Damage:
                return SkillActionBehaviorDetail.BehaviorType.Damage;
            case SkillActionType.Heal:
                return SkillActionBehaviorDetail.BehaviorType.Heal;
            case SkillActionType.AddBuff:
                return SkillActionBehaviorDetail.BehaviorType.AddBuff;
            default:
                return SkillActionBehaviorDetail.BehaviorType.RemoveBuff;
        }
    }
}
