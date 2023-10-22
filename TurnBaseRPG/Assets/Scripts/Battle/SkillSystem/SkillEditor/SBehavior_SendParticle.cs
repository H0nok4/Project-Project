using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TimelineExtension;
using UnityEngine;

namespace SkillEditor {
    public class SBehavior_SendParticle : BaseBehaviour {
        protected override void OnStart(object binding)
        {
            var clip = GetData<SClip_SendParticle>();
            Debug.Log($"技能表现开始播放粒子特效，名称为{clip.ParticleName}");
        }
    }
}
