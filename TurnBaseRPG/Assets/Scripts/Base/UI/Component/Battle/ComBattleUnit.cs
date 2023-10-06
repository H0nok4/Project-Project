using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class ComBattleUnit : UIComponent
{
    public Image UnitImage;

    public override void InitInstance()
    {
        UnitImage = GetImageAtChildIndex(0);
    }
}
