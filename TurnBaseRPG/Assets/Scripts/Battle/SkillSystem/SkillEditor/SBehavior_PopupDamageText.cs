using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Base;
using Battle;
using TimelineExtension;
using UnityEngine;

namespace SkillEditor {
    public class SBehavior_PopupDamageText : BaseBehaviour{
        protected override void OnStart(object binding)
        {
            //�����˺��������޸���ɫ��������������������
            if (BattleStage.Instance.SkillTimelineData == null)
            {
                return;
            }

            var clip = GetData<SClip_PopupDamageText>();
            switch (clip.Type)
            {
                case PopupDamageType.TargetDamage:
                    EventManager.Instance.TriggerEvent<float,Transform>(EventDef.PopupDamageText,BattleStage.Instance.SkillTimelineData.TargetDamageDetail.TrueValue * clip.DamagePercentage, BattleStage.Instance.SkillTimelineData.TargetDamageDetail.TargetUnit.GO.transform);
                    break;
            }

            Debug.Log($"�����˺�ֵ��Ϊ�ô��˺��ģ�{clip.DamagePercentage}%");
        }
    }
}
