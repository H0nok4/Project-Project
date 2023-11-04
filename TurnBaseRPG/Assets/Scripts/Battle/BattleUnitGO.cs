using ConfigType;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Battle {
    [Serializable]
    public class BattleUnitGO : MonoBehaviour {
        public BattleUnit Unit;
        public SpriteAnimator Animator;

        public BattleUnitGO(BattleUnit unit)
        {
            Unit.GO = this;
            Unit = unit;
        }

        public void Init() {
            EventManager.Instance.AddListener<BattleEvent_BattleUnitApplyDamage>(BattleEvent_BattleUnitApplyDamage.EventName, HandleApplyDamage);
            EventManager.Instance.AddListener<BattleEvent_BattleUnitApplyHeal>(BattleEvent_BattleUnitApplyHeal.EventName, HandleApplyHeal);
        }

        private void HandleApplyDamage(BattleEvent_BattleUnitApplyDamage damageEvent)
        {
            if (damageEvent.Unit != this.Unit)
            {
                return;
            }

            //TODO:弹出伤害的文字
            var textGo = GameObject.Instantiate(DataManager.Instance.GetUIPrefabByName("DamageText"), Vector3.zero, Quaternion.identity);
            DamageText damageText = textGo.GetComponent<DamageText>();
            damageText.SetDamage((int)damageEvent.DamagedHP);
            textGo.transform.SetParent(this.transform);
            textGo.transform.localScale = Vector3.one;
            textGo.transform.localPosition = Vector3.zero;
            //TODO:血条放在血条自己的事件里
            //if (this.Unit == CurrentPlayerBattleUnit) {
            //    BattleUIManager.SetPlayerHP(value, go.Unit);
            //}
            //else if (go.Unit == CurrentEnemyBattleUnit) {
            //    BattleUIManager.SetEnemyHP(value, go.Unit);
            //}
        }

        private void HandleApplyHeal(BattleEvent_BattleUnitApplyHeal healEvent)
        {
            //TODO:弹出治疗的文字
        }

        public void Dispose()
        {
            EventManager.Instance.RemoveListener<BattleEvent_BattleUnitApplyDamage>(BattleEvent_BattleUnitApplyDamage.EventName, HandleApplyDamage);
            EventManager.Instance.RemoveListener<BattleEvent_BattleUnitApplyHeal>(BattleEvent_BattleUnitApplyHeal.EventName,HandleApplyHeal);
        }

        ~BattleUnitGO()
        {
            Debug.Log("销毁一个BattleUnitGO");
            Dispose();
        }
    }

    [Serializable]
    public class SpriteAnimator {
        public List<SpriteAnimation> Animations;

        public SpriteAnimator() {
            Animations = new List<SpriteAnimation>();
        }

    }

    [Serializable]
    public class SpriteAnimation {
        public string Name;
        public Sprite Sprite;
    }
}
