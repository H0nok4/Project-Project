using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConfigType;

[SerializeField]
public class PokeGirl 
{
    //��ɫ���У���Ҫ��������ֵ�����������������ֵ������ֵ������ֵ������Pokemon�����Ľ�ɫ��
    public int Id;

    public string Name;

    public int Level;

    public int Exp;

    /// <summary>
    /// ��ǰ�Ƿ�Ϊ��ս��λ
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// ��ǰ��λ�Ƿ�Ϊ����״̬
    /// </summary>
    public bool IsDead;

    /// <summary>
    /// ��ǰ������ֵ
    /// </summary>
    public float CurrentHp;
    /// <summary>
    /// ���ȳ�ս��λ
    /// </summary>
    public bool IsFirst;

    /// <summary>
    /// �������Ժ�����ֵ���
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
            //TODO:���������BUFF֮���
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
