using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battle.SkillSystem.SkillEditor {
    public enum AnimationTarget {
        Source,
        Target
    }
    public class SClip_PlayAnimation : BaseClipAsset<SBehavior_PlayAnimation> {
        public string AnimationName;
        public AnimationTarget AnimationTarget;
        public float Duration;
    }
}
