using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ConfigType {
    public partial class DataManager {

        public List<TimelineAsset> SkillTimelineAssets = new List<TimelineAsset>();
        public Dictionary<string, TimelineAsset> SkillTimelineAssetsDic = new Dictionary<string, TimelineAsset>();

        public List<GameObject> UIPrefabs = new List<GameObject>();
        public Dictionary<string, GameObject> UIPrefabsDic = new Dictionary<string, GameObject>();
        public void InitResources()
        {
            string resourcesPath = "Assets/Resources/";
            SkillTimelineAssets =
                ResourceLoadManager.Instance.Load<TimelineAsset>("Skill/TimelineData/");

            UIPrefabs = ResourceLoadManager.Instance.Load<GameObject>("UIPrefab/Battle/");

            InitResourceDictionary();
        }

        public TimelineAsset GetSkillTimelineAssetByName(string name)
        {
            if (SkillTimelineAssetsDic.ContainsKey(name))
            {
                return SkillTimelineAssetsDic[name];
            }
            else
            {
                Debug.LogError($"不存在名为{name}的Timeline资源");
                return null;
            }
        }

        public GameObject GetUIPrefabByName(string name)
        {
            if (UIPrefabsDic.ContainsKey(name))
            {
                return UIPrefabsDic[name];
            }
            else
            {
                Debug.LogError($"不存在名为{name}的UIPrefab资源");
                return null;
            }
        }   

        public void InitResourceDictionary()
        {
            foreach (var skillTimelineAsset in SkillTimelineAssets)
            {
                SkillTimelineAssetsDic.Add(skillTimelineAsset.name,skillTimelineAsset);
            }

            foreach (var uiPrefab in UIPrefabs)
            {
                UIPrefabsDic.Add(uiPrefab.name,uiPrefab);
            }
        }
    }
}
