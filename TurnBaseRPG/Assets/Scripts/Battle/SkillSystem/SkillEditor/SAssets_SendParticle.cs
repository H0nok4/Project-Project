
using Assets.Scripts.Battle;
using TimelineExtension;
using UnityEngine;
using UnityEngine.Timeline;

namespace SkillEditor {
    [TrackColor(0,0,1)]
    [TrackClipType(typeof(SClip_SendParticle))]
    [TrackBindingType(typeof(BattleUnitGO))]
    public class SAssets_SendParticle : BaseTrackAsset {

    }
}
