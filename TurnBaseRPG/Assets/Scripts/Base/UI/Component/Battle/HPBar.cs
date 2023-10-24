using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle
{
    public class HPBar : UIComponent {
        public Image m_Background;
        public Image m_valueImage;

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
            var currentFillAmount = unit.CurrentHP / unit.CurrentHP;
            if (m_valueImage.fillAmount > currentFillAmount)
            {
                //TODO:动效减少
                StartCoroutine(TweenHP(currentFillAmount,m_valueImage.fillAmount));
            }
        }

        private IEnumerator TweenHP(float current,float pre)
        {
            float value = pre;
            while (value > current)
            {
                SetValue(value);
                value -= Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }
    }

}

