using System;
using System.Collections;
using System.Collections.Generic;
using ConfigType;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class SkillCard{
    public int SkillID;
    //TODO:当前拥有的技能卡
    public int Cost => Define.Cost;
    public SkillBaseDefine Define => DataManager.Instance.GetSkillBaseDefineByID(SkillID);
    public string Describe => Define.SkillDes;
    public SkillTargetType TargetType => Define.SkillTargetType;
    public SkillType SkillType => Define.SkillType;

    public List<SkillActionBase> SkillActions;

    public GameObject TimelineObject => DataManager.Instance.GetSkillTimelineAssetByName(Define.TimeLineData);

    public SkillCard(int skillID)
    {
        SkillID = skillID;
        SkillActions = new List<SkillActionBase>();
        foreach (var actionID in Define.SkillActions)
        {
            SkillActions.Add(new SkillActionBase(actionID));
        }
    }

}