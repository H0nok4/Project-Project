using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConfigType;

[SerializeField]
public class PokeGirl 
{
    //角色类中，需要基础属性值，计算升级后的属性值，个体值，种族值，类似Pokemon那样的角色类
    public int Id;

    public string Name;

    public int Level;

    public int Exp;

    /// <summary>
    /// 当前是否为出战单位
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// 当前单位是否为阵亡状态
    /// </summary>
    public bool IsDead;

    /// <summary>
    /// 当前的生命值
    /// </summary>
    public float CurrentHp;
    /// <summary>
    /// 首先出战单位
    /// </summary>
    public bool IsFirst;

    /// <summary>
    /// 基础属性和种族值相关
    /// </summary>
    public PokeGirlAttributeBaseDefine AttributeBase =>
        DataManager.Instance.GetPokeGirlAttributeBaseDefineByID(BaseDefine.AttributeID);

    public PokeGirlBaseDefine BaseDefine => DataManager.Instance.GetPokeGirlBaseDefineByID(Id);

    public List<SkillBase> EquipedSkills = new List<SkillBase>();

    public PokeGirl(int id, int level)
    {
        Id = id;
        Level = level;
        CurrentHp = MaxHP;
        Exp = 0;
    }

    public float Attack
    {
        get
        {
            //TODO:后面可能有BUFF之类的
            return AttributeBase.AttackBase + AttributeBase.AttackGrow * Level;
        }
    }

    public float Defense
    {
        get
        {
            return AttributeBase.DefenseBase + AttributeBase.DefenseGrow * Level;
        }
    }

    public float SpAttack
    {
        get
        {
            return AttributeBase.SpAttackBase + AttributeBase.SpAttackGrow * Level;
        }
    }

    public float SpDefense
    {
        get
        {
            return AttributeBase.SpDefenseBase + AttributeBase.SpDefenseGrow * Level;
        }
    }

    public float CriticalChanceBase
    {
        get
        {
            return AttributeBase.CriticalChanceBase;
        }
    }

    public float CriticalDamage
    {
        get
        {
            return AttributeBase.CriticalDamageBase;
        }
    }

    public float MaxHP
    {
        get
        {
            return AttributeBase.MaxHpBase + AttributeBase.MaxHpGrow * Level;
        }
    }

    public float MaxSkillPoint
    {
        get
        {
            return AttributeBase.SkillPointNum;
        }
    }

    public float SpeedBase
    {
        get
        {
            return AttributeBase.SpeedBase;
        }
    }

    public float InjuryReductionRate
    {
        get
        {
            return AttributeBase.InjuryReductionRateBase;
        }
    }

    public float InjuryDamageBase
    {
        get
        {
            return AttributeBase.InjuryDamageBase;
        }
    }

}
