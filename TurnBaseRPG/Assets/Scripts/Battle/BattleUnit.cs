using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:��ǰս���ĵ�λ
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// ��ǰ��λ
    /// </summary>
    public PokeGirl PokeGirl;

    public List<SkillCard> HandleSkillCards;

    public BattleUnit(PokeGirl pokeGirl) {
        PokeGirl = pokeGirl;
        HandleSkillCards = new List<SkillCard>();
    }

    public void AddSkillCard(SkillCard skillCard)
    {
        //TODO:�Ժ���Ҫ�ж�������
        HandleSkillCards.Add(skillCard);
    }

}
