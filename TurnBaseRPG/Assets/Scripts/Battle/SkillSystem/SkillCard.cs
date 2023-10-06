using System.Collections;
using System.Collections.Generic;
using ConfigType;
using JetBrains.Annotations;
using UnityEngine;

public class SkillCard : IBattlePerformable {
    public int SkillID;
    //TODO:当前拥有的技能卡
    public int Cost => Define.Cost;
    public SkillBaseDefine Define => DataManager.Instance.GetSkillBaseDefineByID(SkillID);

    public string Describe => Define.SkillDes;
    public SkillTargetType TargetType => Define.SkillTargetType;
    public SkillType SkillType => Define.SkillType;

    public SkillCard(int skillID)
    {
        SkillID = skillID;
    }

    public void OnPerform(BattleUnit activeUnit, BattleUnit targetUnit)
    {
        
    }
}