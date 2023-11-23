using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Battle
{
    public class BtnEndTurn : ButtonBase {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            Debug.Log("结束回合按钮被按下");
            EventManager.Instance.TriggerEvent(EventDef.OnClickBattleEndTurnButton);
        }
    }

}

