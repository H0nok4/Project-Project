using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    }

}

