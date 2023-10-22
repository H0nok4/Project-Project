using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Battle {
    public class BattleUnitGO : MonoBehaviour {
        public BattleUnit Unit;
        public SpriteAnimator Animator;

        public BattleUnitGO(BattleUnit unit)
        {
            Unit.GO = this;
            Unit = unit;
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
