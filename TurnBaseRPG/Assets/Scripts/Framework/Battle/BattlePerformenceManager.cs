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
            var timelineObject = GameObject.Instantiate(skillDetail.Skill.TimelineObject);
            BattleStage.Instance.TimeLineDirector = timelineObject.GetComponent<PlayableDirector>();
            BattleStage.Instance.TimeLineDirector.Play();
            //TODO:给TimelineData绑定数据
            foreach (var playableBinding in BattleStage.Instance.TimeLineDirector.playableAsset.outputs) {
                BattleStage.Instance.TimeLineDirector.SetGenericBinding(playableBinding.sourceObject, skillDetail);
            }


            Debug.Log($"开始播放技能的表现，技能表现时常为：{BattleStage.Instance.TimeLineDirector.playableAsset.duration}");
            yield return new WaitForSeconds((float)BattleStage.Instance.TimeLineDirector.playableAsset.duration);
            BattleStage.Instance.TimeLineDirector.Stop();
            BattleStage.Instance.TimeLineDirector = null;
            GameObject.Destroy(timelineObject);
        }
    }
}
