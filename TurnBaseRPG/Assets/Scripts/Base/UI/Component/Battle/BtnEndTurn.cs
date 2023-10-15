using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Base;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Battle
{
    public class BtnEndTurn : ButtonBase {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            Debug.Log("�����غϰ�ť������");
            EventManager.Instance.TriggerEvent(EventDef.OnClickBattleEndTurnButton);
        }
    }

}

