using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle;
using TimelineExtension;
using UnityEngine;
using UnityEngine.Timeline;

namespace SkillEditor {
    [TrackColor(1,0,0)]
    [TrackBindingType(typeof(DamageDetail))]
    [TrackClipType(typeof(SClip_PopupDamageText))]
    public class SAssets_PopupDamageText : BaseTrackAsset {

    }
}
