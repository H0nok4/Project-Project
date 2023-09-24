using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSelector : UIComponent
{
    public UIList ListSkillMove;
    public override void InitInstance()
    {
        ListSkillMove = GetUIListAtChildIndex(1);
    }
}
