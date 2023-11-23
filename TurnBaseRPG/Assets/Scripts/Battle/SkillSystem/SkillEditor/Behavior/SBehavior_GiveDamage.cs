using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle;
using TimelineExtension;
using UnityEngine;

namespace SkillEditor {
    public class SBehavior_GiveDamage : BaseBehaviour{
        protected override void OnStart(object binding) {

            //根据伤害的类型修改颜色，暴击的字体更大更鲜艳
            
            var clip = GetData<SClip_GiveDamage>();
            //TODO:根据Clip的类型造成伤害
            var bindingData = (BattleUseSkillDetail) binding;
            var damageValue = (int)clip.CalculateDamage(bindingData.Source.Unit, bindingData.Target.Unit);
            var unit = clip.TargetType == SkillActionTarget.Target ? bindingData.Target.Unit : bindingData.Source.Unit;

            unit.ApplyDamage(damageValue);
            BattleEvent_BattleUnitApplyDamage.Trigger(unit, damageValue);
            Debug.Log($"弹出伤害值：{damageValue}");
        }


    }
}
