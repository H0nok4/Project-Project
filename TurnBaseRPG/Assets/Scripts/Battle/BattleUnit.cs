using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:当前战斗的单位
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// 当前单位
    /// </summary>
    public PokeGirl PokeGirl;

    public List<SkillCard> HandleSkillCards;

    //TODO:需要将基础值计算为被各种BUFF道具等影响的最终值

    public BattleUnit(PokeGirl pokeGirl) {
        PokeGirl = pokeGirl;
        HandleSkillCards = new List<SkillCard>();
    }

    public bool IsDead => false;
    public void AddSkillCard(SkillCard skillCard)
    {
        //TODO:以后需要判断数量等
        HandleSkillCards.Add(skillCard);
    }

}
