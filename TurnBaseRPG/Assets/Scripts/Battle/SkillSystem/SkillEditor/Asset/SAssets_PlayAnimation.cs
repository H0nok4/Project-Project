using Assets.Scripts.Battle;
using TimelineExtension;
using UnityEngine.Timeline;
namespace SkillEditor {
    [TrackColor(0,1,0)]
    [TrackClipType(typeof(SClip_PlayAnimation))]
    [TrackBindingType(typeof(BattleUnitGO))]
    public class SAssets_PlayAnimation : BaseTrackAsset {

    }
}