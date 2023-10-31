using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimelineExtension;
using UnityEngine;

namespace SkillEditor {
    public class SBehavior_PlayAnimation : BaseBehaviour {
        protected override void OnStart(object binding) {
            var data = GetData<SClip_PlayAnimation>();
            Debug.Log($"技能表现开始播放动画,动画名称为:{data.AnimationName}");
        }
    }
}
