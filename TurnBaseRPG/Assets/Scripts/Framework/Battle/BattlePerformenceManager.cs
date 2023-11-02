using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Battle {
    public  static class BattlePerformanceManager {

        public static IEnumerator Perform(BattleUseSkillDetail skillDetail,BattleUnit sourceUnit,BattleUnit targetUnit) {
            List<string> nameList = new List<string>();
            BattleStage.Instance.TimeLineDirector.playableAsset = skillDetail.Skill.TimelineAssets;
            foreach (var playableBinding in BattleStage.Instance.TimeLineDirector.playableAsset.outputs) {
                BattleStage.Instance.TimeLineDirector.SetGenericBinding(playableBinding.sourceObject, skillDetail);
            }

            BattleStage.Instance.TimeLineDirector.Play();
            //TODO:给TimelineData绑定数据

            Debug.Log($"开始播放技能的表现，技能表现时常为：{skillDetail.Skill.TimelineAssets.duration}");
            yield return new WaitForSeconds((float)skillDetail.Skill.TimelineAssets.duration);
            BattleStage.Instance.TimeLineDirector.Stop();
        }
    }
}
