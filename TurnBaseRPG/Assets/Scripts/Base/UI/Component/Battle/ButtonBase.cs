using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonBase : UIComponent,IPointerClickHandler
    {
        public Action OnClick;
        public override void InitInstance()
        {
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public override void InitInstance() {

        }
    }

}

