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
    /// 基础属性和种族值相关
    /// </summary>
    public PokeGirlAttributeBase AttributeBase =>
        DataManager.Instance.GetPokeGirlAttributeBaseByID(BaseDefine.AttributeID);

    public PokeGirlBase BaseDefine => DataManager.Instance.GetPokeGirlBaseByID(Id);
    
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
