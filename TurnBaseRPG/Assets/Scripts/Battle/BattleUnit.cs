using System;
using System.Collections;
using System.Collections.Generic;
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



    public BattleUnit(PokeGirl pokeGirl) {
        PokeGirl = pokeGirl;
        HandleSkillCards = new List<SkillCard>();
        AttributeDic = new Dictionary<AttributeType, float>();
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
