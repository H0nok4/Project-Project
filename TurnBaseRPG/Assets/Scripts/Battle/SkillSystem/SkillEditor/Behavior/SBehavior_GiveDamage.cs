using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Base;
using Assets.Scripts.Battle;
using Battle;
using TimelineExtension;
using UnityEngine;

namespace SkillEditor {
    public class SBehavior_GiveDamage : BaseBehaviour{
        protected override void OnStart(object binding) {
            BattleEvent_BattleUnitApplyDamage data = new BattleEvent_BattleUnitApplyDamage();
            //根据伤害的类型修改颜色，暴击的字体更大更鲜艳
            
            var clip = GetData<SClip_GiveDamage>();
            //TODO:根据Clip的类型造成伤害
            var bindingData = (BattleUseSkillDetail) binding;
            switch (clip.TargetType) {
                case SkillActionTarget.Target:
                    bindingData.Target.Unit.ApplyDamage(clip.CalculateDamage(bindingData.Source.Unit,bindingData.Target.Unit));
                    break;
                case SkillActionTarget.Self:
                    break;
            }

            EventManager.Instance.TriggerEvent(BattleEvent_BattleUnitApplyDamage.EventName, data);
            Debug.Log($"弹出伤害值：为该次伤害的：{clip}%");
        }
    }
}
