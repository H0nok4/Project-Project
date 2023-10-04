using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class SkillBase : IBattlePerformable
{
    public int ID { get; }

    public string Name => Define.SkillName;

    public SkillBaseDefine Define => DataManager.Instance.GetSkillBaseDefineByID(ID);

    public SkillBase(int id)
    {
        ID = id;
    }
    public virtual void OnPerform(BattleUnit activeUnit, BattleUnit targetUnit)
    {
        
    }
}
