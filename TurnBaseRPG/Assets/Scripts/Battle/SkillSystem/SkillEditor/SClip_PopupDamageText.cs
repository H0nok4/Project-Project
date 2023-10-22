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
        TargetDamage,
        SourceDamage,
        TargetHeal,
        SourceHeal
    }
    public class SClip_PopupDamageText : BaseClipAsset<SBehavior_PopupDamageText>
    {
        public PopupDamageType Type;
        public float DamagePercentage;
        //TODO:ÑÕÉ«£¿
    }
}
