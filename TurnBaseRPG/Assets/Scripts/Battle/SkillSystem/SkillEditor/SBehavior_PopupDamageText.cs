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
    public class SBehavior_PopupDamageText : BaseBehaviour{
        protected override void OnStart(object binding)
        {
            //根据伤害的类型修改颜色，暴击的字体更大更鲜艳
            if (BattleStage.Instance.SkillTimelineData == null)
            {
                return;
            }

            var clip = GetData<SClip_PopupDamageText>();
            switch (clip.Type)
            {
                case PopupDamageType.TargetDamage:
                    //TODO:因为弹出伤害数字血条也要相应改变,则放在这里一起
                    
                    break;
            }

            Debug.Log($"弹出伤害值：为该次伤害的：{clip.DamagePercentage}%");
        }
    }
}
