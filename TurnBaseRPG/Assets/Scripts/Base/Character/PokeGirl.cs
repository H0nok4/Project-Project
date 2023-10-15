using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConfigType;
using static UnityEngine.Rendering.DebugUI;
using System;

[SerializeField]
public class PokeGirl 
{
    //角色类中，需要基础属性值，计算升级后的属性值，个体值，种族值，类似Pokemon那样的角色类
    public int Id;

    public string Name;

    private int _level;

    private int _exp;

    /// <summary>
    /// 当前是否为出战单位
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// 当前单位是否为阵亡状态
    /// </summary>
    public bool IsDead;

    /// <summary>
    /// 首先出战单位
    /// </summary>
    public bool IsFirst;

    public int Level
    { 
        get => _level;
        set
        {
            _level = value;
            RefreshState();
        }
    }

    public int Exp
    {
        get => _level;
        set => _level = value;
    }

    /// <summary>
    /// 基础属性和种族值相关
    /// </summary>
    public PokeGirlAttributeBaseDefine AttributeBase =>
        DataManager.Instance.GetPokeGirlAttributeBaseDefineByID(BaseDefine.AttributeID);

    public PokeGirlBaseDefine BaseDefine => DataManager.Instance.GetPokeGirlBaseDefineByID(Id);

    public Dictionary<AttributeType, float> StateDic = new Dictionary<AttributeType, float>();

    public PokeGirl(int id, int level)
    {
        Id = id;
        Level = level;
        Exp = 0;

        RefreshState();
        //TODO:Test
    }

    public void RefreshState()
    {
        StateDic.Clear();
        var attributeEnums = Enum.GetValues(typeof(AttributeType));
        foreach (var attributeEnum in attributeEnums) {
            switch (attributeEnum) {
                case AttributeType.MaxHP:
                    StateDic.Add(AttributeType.MaxHP, AttributeBase.MaxHpBase + AttributeBase.MaxHpGrow * (Level - 1));
                    break;
                case AttributeType.Attack:
                    StateDic.Add(AttributeType.Attack, AttributeBase.MaxHpBase + AttributeBase.MaxHpGrow * (Level - 1));
                    break;
                case AttributeType.Defense:
                    StateDic.Add(AttributeType.Defense, AttributeBase.DefenseBase);
                    break;
                case AttributeType.SPAttack:
                    StateDic.Add(AttributeType.SPAttack, AttributeBase.MaxHpBase + AttributeBase.MaxHpGrow * (Level - 1));
                    break;
                case AttributeType.SPDefense:
                    StateDic.Add(AttributeType.SPDefense, AttributeBase.SpDefenseBase + AttributeBase.SpDefenseGrow * (Level - 1));
                    break;
                case AttributeType.CriticalChance:
                    StateDic.Add(AttributeType.CriticalChance, AttributeBase.CriticalChanceBase);
                    break;
                case AttributeType.Speed:
                    StateDic.Add(AttributeType.Speed, AttributeBase.MaxHpBase + AttributeBase.MaxHpGrow * (Level - 1));
                    break;
                case AttributeType.SkillPoint:
                    StateDic.Add(AttributeType.SkillPoint,AttributeBase.SkillPointNum);
                    break;
                default:
                    break;
            }
        }
    }

    public float GetStateBaseByAttributeType(AttributeType type)
    {
        if (!StateDic.ContainsKey(type))
        {
            Debug.LogError("需要获取不存在的属性类型");
            return 0;
        }

        return StateDic[type];
    }

}
