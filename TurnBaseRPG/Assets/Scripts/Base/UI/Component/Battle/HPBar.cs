using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle
{
    public class HPBar : UIComponent {
        public Image m_Background;
        public Image m_valueImage;
        public Coroutine TweenCoroutine;

        public float Value {
            get {
                return m_valueImage.transform.localScale.x;
            }
            set => SetValue(value);
        }
        public override void InitInstance() {
            m_Background = GetImageAtChildIndex(0);
            m_valueImage = GetImageAtChildIndex(1);
        }

        public void SetValue(float value)
        {
            m_valueImage.transform.localScale = new Vector3(value, 1, 1);
        }

        public void InitHPBar(BattleUnit unit)
        {
            SetValue(unit.CurrentHP / unit.MaxHP);
        }

        public void RefreshHPBar(BattleUnit unit)
        {
            //TODO：血量减少了需要动效
            SetValue(unit.CurrentHP / unit.MaxHP);
        }

        public void RefreshHP(float value,float max) {
            var targetFillAmount = value / max;
            if (Mathf.Abs(Value - tweenTargetAmount) > Single.Epsilon) {
                //TODO:动效减少
                lerpValue = 0;
                tweenTargetAmount = targetFillAmount;
                if (TweenCoroutine != null) {
                    return;
                }

                tweenTargetAmount = targetFillAmount;
                TweenCoroutine = StartCoroutine(TweenHP());
            }
        }

        private float tweenTargetAmount;
        private float lerpValue;
        private IEnumerator TweenHP()
        {
            while (Mathf.Abs(Value - tweenTargetAmount) > Single.Epsilon) {
                var newValue = Mathf.Lerp(Value, tweenTargetAmount, lerpValue);
                lerpValue += 2 * Time.deltaTime;
                SetValue(newValue);
                yield return new WaitForEndOfFrame();
            }

            TweenCoroutine = null;
        }
    }

}

