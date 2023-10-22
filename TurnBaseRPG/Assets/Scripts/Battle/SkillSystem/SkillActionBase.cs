using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class SkillActionBase
{
    //技能动作的基类
    public int ID;
    public SkillActionBaseDefine Define => DataManager.Instance.GetSkillActionBaseDefineByID(ID);
    public SkillActionTarget Target => Define.ActionTarget;
    public SkillActionType Type => Define.ActionType;

    public List<ValueOperateType> OperateType => Define.ActionValueOperateType;
    public List<ValueRelateUnit> RelateUnitType => Define.ActionValueRelateUnitType;
    public List<float> Values => Define.Value;
    public List<ValueOperateType> DiffValueOperateTypes => Define.DifferentValueOperateType;
    public List<SkillActionTarget> ValueTarget => Define.ActionValueTarget;
    public SkillActionBase(int id)
    {
        ID = id;
    }
}
