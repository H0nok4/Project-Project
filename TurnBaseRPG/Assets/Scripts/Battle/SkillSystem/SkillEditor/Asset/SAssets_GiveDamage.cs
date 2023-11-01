using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Battle;
using Battle;
using TimelineExtension;
using UnityEngine;
using UnityEngine.Timeline;

namespace SkillEditor {
    [Serializable]
    public class BattleUseSkillDetail {
        public BattleUnitGO Source;
        public BattleUnitGO Target;
        public SkillCard Skill;
    }

    [TrackColor(1,0,0)]
    [TrackBindingType(typeof(BattleUseSkillDetail))]
    [TrackClipType(typeof(SClip_GiveDamage))]
    public class SAssets_GiveDamage : BaseTrackAsset {

    }
}
