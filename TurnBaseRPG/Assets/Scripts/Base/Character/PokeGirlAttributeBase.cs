using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PokeGirlAttributeBase : Defs
{
    public int Id;
    
    /// <summary>
    /// 基础的技能点数量
    /// </summary>
    public int SkillPointNum;

    //1级的基础属性
    [Header("1级时的最大生命值"),PokeGirlAttributeType(PokeGirlAttributeType.MaxHP)]
    public int MaxHpBase;
    [Header("1级时的基础攻击力"),PokeGirlAttributeType(PokeGirlAttributeType.Attack)]
    public int AttackBase;
    [Header("1级时的基础防御力"),PokeGirlAttributeType(PokeGirlAttributeType.Defend)]
    public int DefenseBase;
    [Header("1级时的基础特殊攻击力"),PokeGirlAttributeType(PokeGirlAttributeType.SpAttack)]
    public int SpAttackBase;
    [Header("1级时的基础特殊防御力"),PokeGirlAttributeType(PokeGirlAttributeType.SpDefend)]
    public int SpDefenseBase;
    [Header("1级时的基础速度"),PokeGirlAttributeType(PokeGirlAttributeType.Speed)]
    public int SpeedBase;

    [Header("1级时的暴击率"),PokeGirlAttributeType(PokeGirlAttributeType.CriticalChance)]
    public float CriticalChanceBase;
    [Header("1级时的暴击伤害"),PokeGirlAttributeType(PokeGirlAttributeType.CriticalDamage)]
    public float CriticalDamageBase;
    [Header("1级时的减伤率"),PokeGirlAttributeType(PokeGirlAttributeType.InjuryReductionRate)]
    public float InjuryReductionRateBase;
    [Header("1级时的增伤率"),PokeGirlAttributeType(PokeGirlAttributeType.InjuryDamageRate)]
    public float InjuryDamageBase;


    //种族成长值
    [Header("每级成长的生命值"),PokeGirlAttributeGrowType(PokeGirlAttributeType.MaxHP)]
    public int MaxHpGrow;
    [Header("每级成长的攻击力"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Attack)]
    public int AttackGrow;
    [Header("每级成长的防御力"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Defend)]
    public int DefenseGrow;
    [Header("每级成长的特殊攻击力"),PokeGirlAttributeGrowType(PokeGirlAttributeType.SpAttack)]
    public int SpAttackGrow;
    [Header("每级成长的特殊防御力"),PokeGirlAttributeGrowType(PokeGirlAttributeType.SpDefend)]
    public int SpDefenseGrow;
    [Header("每级成长的速度"),PokeGirlAttributeGrowType(PokeGirlAttributeType.Speed)]
    public int SpeedGrow;
}
