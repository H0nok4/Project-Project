using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfigType
{
    public enum SkillType
    {
        Physics,
        Fire,
        Cold,
        Nature,
        Psyche
    }

    public enum SkillTargetType
    {
        Self,
        Other,
        All
    }

    public enum SkillLearnTag
    {
        All
    }

    public enum SkillActionTarget
    {
        Target,
        User,
        All
    }

    public enum SkillActionType
    {
        Damage,
        Heal,
        AddBuff,
        RemoveBuff
    }

    public enum AttributeType
    {
        MaxHP,
        SkillPoint,
        Attack,
        SPAttack,
        Defense,
        SPDefense,
        Speed,
        CriticalChance
    }

    public class NPCBaseDefine
    {
        public int ID; // ID 
        public string Name; // 名称 
        public List<int> BattlePartyID; // 拥有的出战角色ID 
        public List<int> BattlePartyLevel; // 拥有的出战角色Level 
    }

    public class PokeGirlAttributeBaseDefine
    {
        public int ID; // ID 
        public int SkillPointNum; // 基础的技能点数量 
        public int MaxHpBase; // 1级时的最大生命值 
        public int AttackBase; // 1级时的基础攻击力 
        public int DefenseBase; // 1级时的基础防御力 
        public int SpAttackBase; // 1级时的基础特殊攻击力 
        public int SpDefenseBase; // 1级时的基础特殊防御力 
        public int SpeedBase; // 1级时的基础速度 
        public float CriticalChanceBase; // 1级时的暴击率 
        public float CriticalDamageBase; // 1级时的暴击伤害 
        public float InjuryReductionRateBase; // 1级时的减伤率 
        public float InjuryDamageBase; // 1级时的增伤率 
        public int MaxHpGrow; // 每级成长的生命值 
        public int AttackGrow; // 每级成长的攻击力 
        public int DefenseGrow; // 每级成长的防御力 
        public int SpAttackGrow; // 每级成长的特殊攻击力 
        public int SpDefenseGrow; // 每级成长的特殊防御力 
        public int SpeedGrow; // 每级成长的速度 
    }

    public class PokeGirlBaseDefine
    {
        public int ID; // ID 
        public string Name; // 名称 
        public string Describe; // 描述 
        public int AttributeID; // 使用的属性基础ID 
        public List<SkillLearnTag> LearnableSkillTags; // 可以学习的技能种类 
    }

    public class SkillActionBaseDefine
    {
        public int ID; // ID 
        public string ActionName; // 效果名称（相当于备注） 
        public SkillActionTarget ActionTarget; // 技能效果目标 
        public SkillActionType ActionType; // 技能效果类型 
        public int Value; // 技能效果值(根据不同的效果类型有不同的规则) 
        public string AdditionClassName; // 额外生效的类名，可以通过反射创建出来，根据不同的技能效果创建不同的基类然后调用不同的虚方法来实现一些复杂的技能效果 
    }

    public class SkillBaseDefine
    {
        public int ID; // ID 
        public string SkillName; // 技能名称 
        public SkillType SkillType; // 技能类型 
        public string SkillDes; // 技能描述 
        public SkillTargetType SkillTargetType; // 技能的目标类型 
        public SkillLearnTag SkillLearnTag; // 可学习技能的类型 
        public int Cost; // 使用技能的消耗 
        public int LevelLimit; // 技能的学习等级条件 
        public List<int> SkillActions; // 技能的效果ID 
    }
}