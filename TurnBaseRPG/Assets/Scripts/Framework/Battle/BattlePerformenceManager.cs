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

        public static IEnumerator Perform(TimelineAsset asset,BattleUnit sourceUnit,BattleUnit targetUnit)
        {
            BattleStage.Instance.TimeLineDirector.playableAsset = asset;
            BattleStage.Instance.TimeLineDirector.Play();

            //TODO:给TimelineData绑定数据

            Debug.Log($"开始播放技能的表现，技能表现时常为：{asset.duration}");
            yield return new WaitForSeconds((float)asset.duration);
            BattleStage.Instance.TimeLineDirector.Stop();
        }
    }
}
