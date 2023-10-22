using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Battle;
using ConfigType;
using UnityEngine;

//TODO:��ǰս���ĵ�λ
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// ��ǰ��λ
    /// </summary>
    public PokeGirl PokeGirl;

    public int CurrentHP;

    public int SkillPoint;

    public List<SkillCard> HandleSkillCards;

    public Dictionary<AttributeType, float> AttributeDic;

    public List<SkillBase> EquipedSkills = new List<SkillBase>();
    //TODO:��Ҫ������ֵ����Ϊ������BUFF���ߵ�Ӱ�������ֵ

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

    public bool IsDead => false;
    public void AddSkillCard(SkillCard skillCard)
    {
        //TODO:�Ժ���Ҫ�ж�������
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
        //TODO:������㻹Ҫ����BUFF��Ӱ��
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



}
