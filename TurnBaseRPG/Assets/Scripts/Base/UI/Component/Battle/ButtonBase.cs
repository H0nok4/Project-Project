using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonBase : UIComponent
    {
        public Action OnClick;

        public override void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public override void InitInstance() {

        }
    }

}

