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
    public SkillActionBase(int id)
    {
        ID = id;
    }
}
