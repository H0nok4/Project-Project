using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle {
    public class BattleDetailBase {
        public float BaseValue;
        public BattleUnit SourceUnit;
        public BattleUnit TargetUnit;
        public bool IsCritical;

        public virtual float TrueValue => BaseValue;

        public virtual bool IsDamage => false;

        public virtual bool IsHeal => false;

    }
    public class DamageDetail : BattleDetailBase
    {
        //TODO:伤害需要计算公式
        public override bool IsDamage => true;
    }

    public class HealDetail : BattleDetailBase
    {
        //治疗可能会有治疗加成等BUFF
        public override bool IsHeal => true;
    }
}
