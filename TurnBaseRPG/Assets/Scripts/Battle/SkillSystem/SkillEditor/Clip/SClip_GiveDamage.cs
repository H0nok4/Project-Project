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
        public PokeGirlAttributeType AttributeType;
        public ValueOperateType OperateType;
        public float Value;
    }


    public class SClip_GiveDamage : BaseClipAsset<SBehavior_GiveDamage> {
        public SkillActionTarget TargetType;
        public List<SkillDamageAction> Actions;

    }
}
