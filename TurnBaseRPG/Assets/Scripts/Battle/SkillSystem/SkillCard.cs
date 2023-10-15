using System.Collections;
using System.Collections.Generic;
using ConfigType;
using JetBrains.Annotations;
using UnityEngine;

public class SkillCard : IBattlePerformable {
    public int SkillID;
    //TODO:��ǰӵ�еļ��ܿ�
    public int Cost => Define.Cost;
    public SkillBaseDefine Define => DataManager.Instance.GetSkillBaseDefineByID(SkillID);
    public string Describe => Define.SkillDes;
    public SkillTargetType TargetType => Define.SkillTargetType;
    public SkillType SkillType => Define.SkillType;

    public List<SkillActionBase> SkillActions;

    public SkillCard(int skillID)
    {
        SkillID = skillID;
        SkillActions = new List<SkillActionBase>();
        foreach (var actionID in Define.SkillActions)
        {
            SkillActions.Add(new SkillActionBase(actionID));
        }
    }

    public virtual IEnumerator OnPerform(BattleUnit activeUnit, BattleUnit targetUnit)
    {
        //TODO:��������ÿ�����ܶ��и��Ե�Ч��
        yield return new WaitForSeconds(0.5f);
    }
}