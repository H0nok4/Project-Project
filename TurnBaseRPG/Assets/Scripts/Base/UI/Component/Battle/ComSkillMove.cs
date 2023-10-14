using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Base;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Battle
{
    public partial class ComSkillMove : UIComponent {
        public Image ImageSkillIcon;
        public TMP_Text TxtSkillDes;
        public TMP_Text TxtSkillPointCost;

        public override void InitInstance() {
            ImageSkillIcon = GetImageAtChildIndex(2);
            TxtSkillDes = GetTextAtChildIndex(3);
            TxtSkillPointCost = GetTextAtChildIndex(5);
        }

        public SkillCard Skill;

        public void Refresh(SkillCard skill)
        {
            Skill = skill;
            //TODO:后面还要刷新贴图
            //ImageSkillIcon.sprite =
            TxtSkillDes.text = skill.Define.SkillDes;
            TxtSkillPointCost.text = skill.Define.Cost.ToString();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (Skill == null)
            {
                //TODO:点击技能卡的时候没有
                Debug.LogError("点击技能卡时没有技能");
                return;
            }

            Debug.Log($"点击了技能卡,技能卡名称为：{Skill.Define.SkillName}");
            EventManager.Instance.TriggerEvent<SkillCard>(EventDef.OnClickBattleCard,Skill);
        }
    }

}

