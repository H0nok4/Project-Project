using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PokeGirlAttributeBase : Defs
{
    public int Id;
    
    /// <summary>
    /// �����ļ��ܵ�����
    /// </summary>
    public int SkillPointNum;

    //1���Ļ�������
    [Header("1��ʱ���������ֵ"),PokeGirlAttributeType(PokeGirlAttributeType.MaxHP)]
    public int MaxHpBase;
    [Header("1��ʱ�Ļ���������"),PokeGirlAttributeType(PokeGirlAttributeType.Attack)]
    public int AttackBase;
    [Header("1��ʱ�Ļ���������"),PokeGirlAttributeType(PokeGirlAttributeType.Defend)]
    public int DefenseBase;
    [Header("1��ʱ�Ļ������⹥����"),PokeGirlAttributeType(PokeGirlAttributeType.SpAttack)]
    public int SpAttackBase;
    [Header("1��ʱ�Ļ������������"),PokeGirlAttributeType(PokeGirlAttributeType.SpDefend)]
    public int SpDefenseBase;
    [Header("1��ʱ�Ļ����ٶ�"),PokeGirlAttributeType(PokeGirlAttributeType.Speed)]
    public int SpeedBase;

    [Header("1��ʱ�ı�����"),PokeGirlAttributeType(PokeGirlAttributeType.CriticalChance)]
    public float CriticalChanceBase;
    [Header("1��ʱ�ı����˺�"),PokeGirlAttributeType(PokeGirlAttributeType.CriticalDamage)]
    public float CriticalDamageBase;
    [Header("1��ʱ�ļ�����"),PokeGirlAttributeType(PokeGirlAttributeType.InjuryReductionRate)]
    public float InjuryReductionRateBase;
    [Header("1��ʱ��������"),PokeGirlAttributeType(PokeGirlAttributeType.InjuryDamageRate)]
    public float InjuryDamageBase;


    //����ɳ�ֵ
    [Header("ÿ���ɳ�������ֵ"),PokeGirlAttributeGrowType(PokeGirlAttributeType.MaxHP)]
    public int MaxHpGrow;
    [Header("ÿ���ɳ��Ĺ�����"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Attack)]
    public int AttackGrow;
    [Header("ÿ���ɳ��ķ�����"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Defend)]
    public int DefenseGrow;
    [Header("ÿ���ɳ������⹥����"),PokeGirlAttributeGrowType(PokeGirlAttributeType.SpAttack)]
    public int SpAttackGrow;
    [Header("ÿ���ɳ������������"),PokeGirlAttributeGrowType(PokeGirlAttributeType.SpDefend)]
    public int SpDefenseGrow;
    [Header("ÿ���ɳ����ٶ�"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Speed)]
    public int SpeedGrow;
}
