using ConfigType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle {
    public class SkillTimelineData
    {
        public BattleDetailBase TargetDamageDetail;
        public BattleDetailBase SourceDamageDetail;
        public BattleDetailBase TargetHealDetail;
        public BattleDetailBase SourceHealDetail;

    }
    public static class BattleDetailGenerator {
        public static SkillTimelineData GenerateSkillDetail(SkillCard skill, BattleUnit sourceUnit, BattleUnit targetUnit) {

            SkillTimelineData result = new SkillTimelineData();

            for (int i = 0; i < skill.SkillActions.Count; i++) {
                switch (skill.SkillActions[i].Type) {
                    case SkillActionType.Damage:
                        //TODO:计算
                        if (skill.SkillActions[i].Target == SkillActionTarget.Target) {
                            result.TargetDamageDetail = CalculateDamageDetail(skill.SkillActions[i], sourceUnit, targetUnit);

                        }
                        else if (skill.SkillActions[i].Target == SkillActionTarget.User) {
                            result.SourceDamageDetail = CalculateDamageDetail(skill.SkillActions[i], sourceUnit, sourceUnit);
                        }
                        break;
                    case SkillActionType.Heal:
                        if (skill.SkillActions[i].Target == SkillActionTarget.Target) {
                            result.TargetHealDetail = CalculateDamageDetail(skill.SkillActions[i], sourceUnit, targetUnit);

                        }
                        else if (skill.SkillActions[i].Target == SkillActionTarget.User) {
                            result.SourceHealDetail = CalculateDamageDetail(skill.SkillActions[i], sourceUnit, sourceUnit);
                        }
                        break;
                    case SkillActionType.AddBuff:
                        break;
                    case SkillActionType.RemoveBuff:
                        break;

                }
            }


            return result;
        }

        private static DamageDetail CalculateDamageDetail(SkillActionBase action, BattleUnit sourceUnit,
            BattleUnit targetUnit) {
            DamageDetail result = new DamageDetail();
            if (action.Target == SkillActionTarget.Target)
            {
                result.SourceUnit = sourceUnit;
                result.TargetUnit = targetUnit;
            }else if (action.Target == SkillActionTarget.User)
            {
                result.SourceUnit = sourceUnit;
                result.TargetUnit = sourceUnit;
            }

            if (action.DiffValueOperateTypes.Count == 0) {
                //TODO:只有一个操作
                switch (action.RelateUnitType[0]) {
                    case ValueRelateUnit.None:
                        result.BaseValue = action.Values[0];
                        break;
                    default:
                        result.BaseValue = GetSkillRelateValue(action.RelateUnitType[0], action.OperateType[0],
                            action.ValueTarget[0] == SkillActionTarget.User ? sourceUnit : targetUnit);
                        break;
                }

            }
            else {
                //TODO：不同数值直接还要计算
                for (int i = 0; i < action.OperateType.Count; i++) {

                }  
            }

            float GetSkillRelateValue(ValueRelateUnit type, ValueOperateType op, BattleUnit unit) {
                switch (type) {
                    case ValueRelateUnit.Atk:
                        return unit.AttributeDic[AttributeType.Attack];
                    case ValueRelateUnit.SpAtk:
                        return unit.AttributeDic[AttributeType.SPAttack];
                    case ValueRelateUnit.Def:
                        return unit.AttributeDic[AttributeType.Defense];
                    case ValueRelateUnit.SpDef:
                        return unit.AttributeDic[AttributeType.SPDefense];
                    default:
                        return 0;
                }
            }

            return result;
        }

        private static float OperateDiffrentValue(ValueOperateType type, float source, float target)
        {
            switch (type)
            {
                case ValueOperateType.Div:
                    return source / target;
                case ValueOperateType.Mul:
                    return source * target;
                case ValueOperateType.Sub:
                    return source - target;
                default:
                    return source + target;
            }
        }

        //public static HealDetail CalculateHealDetail(SkillActionBase action, BattleUnit sourceUnit,
        //    BattleUnit targetUnit)
        //{

        //}

    }
}
