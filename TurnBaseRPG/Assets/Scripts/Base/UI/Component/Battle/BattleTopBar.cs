using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle
{
    public class BattleTopBar : UIComponent {
        public Image m_ImgHead;
        public HPBar m_HPBar;
        public TMP_Text m_TxtName;

        public override void InitInstance() {
            m_ImgHead = GetImageAtChildIndex(0);
            m_HPBar = (HPBar)GetUIComponentAtChildIndex(1);
            m_TxtName = GetTextAtChildIndex(2);
        }
    }

}

