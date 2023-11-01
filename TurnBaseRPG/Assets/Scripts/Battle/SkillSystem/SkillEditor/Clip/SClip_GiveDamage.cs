using System;
using System.Collections.Generic;
using ConfigType;
using TimelineExtension;

namespace SkillEditor {

    public enum SkillActionTarget {
        Target,
        Self
    }

    public enum ActionValueFromTarget {
        Source,
        Target
    }


    [Serializable]
    public class SkillDamageAction {
        public ActionValueFromTarget FromWhere;
        public AttributeType AttributeType;
        public ValueOperateType OperateType;
        public float Value;
    }


    public class SClip_GiveDamage : BaseClipAsset<SBehavior_GiveDamage> {
        public SkillActionTarget TargetType;
        public List<SkillDamageAction> Actions;

        public float CalculateDamage(BattleUnit source, BattleUnit target) {
            float result = 0;
            foreach (var skillDamageAction in Actions) {
                BattleUnit unit = null;
                if (skillDamageAction.FromWhere == ActionValueFromTarget.Source) {
                    unit = source;
                }
                else {
                    unit = target;
                }

                var attributeValue = unit.AttributeDic[skillDamageAction.AttributeType];
                

            }
            return result;
        }
    }
}
