using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class SkillCardBehavior {
    public BattleUnit Owner;

    public SkillCard UsingSkillCard;

    public List<SkillActionBehaviorDetail> Using(BattleUnit target) {
        List<SkillActionBehaviorDetail> result = new List<SkillActionBehaviorDetail>();
        foreach (var action in UsingSkillCard.SkillActions) {
            //TODO:每个动作都独立计算BUFF
            var behaviorDetail = new SkillActionBehaviorDetail();
            behaviorDetail.Type = action.Type.ToBehaviorType();

            if (behaviorDetail.Type == SkillActionBehaviorDetail.BehaviorType.Damage) {
                behaviorDetail.BeforeDamageHP = target.CurrentHP;
            }


        }

        return result;
    }
}
