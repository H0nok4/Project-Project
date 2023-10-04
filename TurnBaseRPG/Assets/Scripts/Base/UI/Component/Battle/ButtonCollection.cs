using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Battle
{
    public class ButtonCollection : UIComponent {
        public BtnBag BtnBag;
        public BtnSwitch BtnSwitch;
        public BtnRunaway BtnRunaway;
        public override void InitInstance()
        {
            BtnBag = (BtnBag)GetUIComponentAtChildIndex(0);
            BtnSwitch = (BtnSwitch)GetUIComponentAtChildIndex(1);
            BtnRunaway = (BtnRunaway)GetUIComponentAtChildIndex(2);
        }
    }
}


