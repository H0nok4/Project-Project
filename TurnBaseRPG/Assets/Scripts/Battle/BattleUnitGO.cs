using ConfigType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Battle {
    public class BattleUnitGO : MonoBehaviour {
        public BattleUnit Unit;
        public SpriteAnimator Animator;

        public BattleUnitGO(BattleUnit unit)
        {
            Unit.GO = this;
            Unit = unit;
            EventManager.Instance.AddListener<BattleEvent_BattleUnitApplyDamage>(BattleEvent_BattleUnitApplyDamage.EventName,HandleApplyDamage);
            EventManager.Instance.AddListener<BattleEvent_BattleUnitApplyHeal>(BattleEvent_BattleUnitApplyHeal.EventName,HandleApplyHeal);
        }

        private void HandleApplyDamage(BattleEvent_BattleUnitApplyDamage damageEvent)
        {
            if (damageEvent.Unit != this.Unit)
            {
                return;
            }

            //TODO:�����˺�������
            var textGo = GameObject.Instantiate(DataManager.Instance.GetUIPrefabByName("DamageText"), Vector3.zero, Quaternion.identity);
            DamageText damageText = textGo.GetComponent<DamageText>();
            damageText.SetDamage((int)damageEvent.DamagedHP);
            textGo.transform.SetParent(this.transform);
            textGo.transform.localScale = Vector3.one;
            textGo.transform.localPosition = Vector3.zero;
            //TODO:Ѫ������Ѫ���Լ����¼���
            //if (this.Unit == CurrentPlayerBattleUnit) {
            //    BattleUIManager.SetPlayerHP(value, go.Unit);
            //}
            //else if (go.Unit == CurrentEnemyBattleUnit) {
            //    BattleUIManager.SetEnemyHP(value, go.Unit);
            //}
        }

        private void HandleApplyHeal(BattleEvent_BattleUnitApplyHeal healEvent)
        {
            //TODO:�������Ƶ�����
        }

        public void Dispose()
        {
            EventManager.Instance.RemoveListener<BattleEvent_BattleUnitApplyDamage>(BattleEvent_BattleUnitApplyDamage.EventName, HandleApplyDamage);
            EventManager.Instance.RemoveListener<BattleEvent_BattleUnitApplyHeal>(BattleEvent_BattleUnitApplyHeal.EventName,HandleApplyHeal);
        }

        ~BattleUnitGO()
        {
            Debug.Log("����һ��BattleUnitGO");
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
