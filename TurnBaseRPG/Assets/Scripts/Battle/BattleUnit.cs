using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using ConfigType;
using UnityEngine;

//TODO:当前战斗的单位
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// 当前单位
    /// </summary>
    public PokeGirl PokeGirl;

    public int CurrentHP;

    public int SkillPoint;

    public List<SkillCard> HandleSkillCards;

    public Dictionary<AttributeType, float> AttributeDic;

    public List<SkillBase> EquipedSkills = new List<SkillBase>();
    //TODO:需要将基础值计算为被各种BUFF道具等影响的最终值

    public BattleUnitGO GO;

    public BattleUnit(PokeGirl pokeGirl) {
        PokeGirl = pokeGirl;
        HandleSkillCards = new List<SkillCard>();
        AttributeDic = new Dictionary<AttributeType, float>();
        RefreshState();
        CurrentHP = (int)MaxHP;
        EquipedSkills.Add(new SkillBase(1));
        EquipedSkills.Add(new SkillBase(1));
        EquipedSkills.Add(new SkillBase(1));
        EquipedSkills.Add(new SkillBase(2));
        EquipedSkills.Add(new SkillBase(2));
    }

    public bool IsDead => CurrentHP <= 0;
    public void AddSkillCard(SkillCard skillCard)
    {
        //TODO:以后需要判断数量等
        HandleSkillCards.Add(skillCard);
    }

    private void RefreshState()
    {
        AttributeDic.Clear();
        foreach (var attributeType in Enum.GetValues(typeof(AttributeType)))
        {
            AttributeDic.Add((AttributeType)attributeType, 0);
        }

        foreach (var attributeType in Enum.GetValues(typeof(AttributeType)))
        {
            AttributeDic[(AttributeType)attributeType] += PokeGirl.GetStateBaseByAttributeType((AttributeType)attributeType);
        }

    }

    public float GetAttrValueByType(AttributeType type)
    {
        //TODO:后面计算还要加上BUFF等影响
        return AttributeDic[type];
    }

    public int MaxSkillPoint
    {
        get
        {
            return (int)PokeGirl.GetStateBaseByAttributeType(AttributeType.SkillPoint);
        }
    }

    public float Speed
    {
        get
        {
            return PokeGirl.GetStateBaseByAttributeType(AttributeType.Speed);
        }
    }

    public float MaxHP
    {
        get
        {
            return PokeGirl.GetStateBaseByAttributeType(AttributeType.MaxHP);
        }
    }

    public override void ApplyDamage(int value) {
        CurrentHP -= value;
        if (IsDead) {
            Debug.Log("单位收到伤害死亡了");
        }

    }
}
