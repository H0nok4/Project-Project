using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle
{
    public class BattleTopBar : UIComponent {
        public Image ImgHead;
        public HPBar HPBar;
        public TMP_Text SkillPointTxt;

        public override void InitInstance() {
            ImgHead = GetImageAtChildIndex(0);
            HPBar = (HPBar)GetUIComponentAtChildIndex(1);
            SkillPointTxt = GetTextAtChildIndex(2);
        }

        public void InitTopBar(BattleUnit unit)
        {
            //m_ImgHead.sprite = unit.Unit.HeadSprite;
            HPBar.InitHPBar(unit);
            SkillPointTxt.text =  "0" + unit.PokeGirl.MaxSkillPoint;
        }

        public void RefreshTopBar(BattleUnit unit)
        {
            //m_ImgHead.sprite = unit.Unit.HeadSprite;
            HPBar.RefreshHPBar(unit);
            SkillPointTxt.text = "0" + unit.PokeGirl.MaxSkillPoint;
        }
    }

}

