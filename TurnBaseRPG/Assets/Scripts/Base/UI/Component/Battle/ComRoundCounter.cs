using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class ComRoundCounter : UIComponent
{
    public TMP_Text TxtRoundNum;
    public override void InitInstance()
    {
        TxtRoundNum = GetTextAtChildIndex(1);
    }

    public void SetRound(int round)
    {
        TxtRoundNum.text = round.ToString();
    }
}
