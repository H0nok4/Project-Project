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
            var detailData = (BattleUseSkillDetail) binding;
            if (data.AnimationTarget == AnimationTarget.Source) {
                if (detailData.Source != null && detailData.Source.gameObject.GetComponent<Animator>() is {} animator) {
                    animator.Play(data.AnimationName);
                }
                else {
                    Debug.LogError("播放自身动画错误,可能没有Animator");
                }
            }

            if (data.AnimationTarget == AnimationTarget.Target) {
                if (detailData.Target != null && detailData.Target.gameObject.GetComponent<Animator>() is { } animator) {
                    animator.Play(data.AnimationName);
                }
                else {
                    Debug.LogError("播放敌方动画错误,可能没有Animator");
                }
            }
        }

        protected override void OnUpdate(object binding, float deltaTime) {
            Debug.Log($"正在更新Animator,当前的DeltaTime为:{deltaTime}");
        }
    }
}
