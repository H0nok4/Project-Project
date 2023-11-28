using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.UserInterface {
    public class BtnInteract : UIComponent {
        public TMP_Text TxtName;
        public override void InitInstance() {
            TxtName = GetTextAtChildIndex(1);
        }
    }

}
