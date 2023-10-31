using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle;
using TimelineExtension;

namespace SkillEditor {
    public enum PopupDamageType
    {
        Target,
        Self
    }

    public class SClip_GiveDamage : BaseClipAsset<SBehavior_GiveDamage>
    {
        public PopupDamageType Type;
        public float DamagePercentage;
        //TODO:颜色？
    }
}
