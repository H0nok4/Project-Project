using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardPool 
{
    private List<SkillCard> cards;

    public SkillCardPool(List<SkillBase> skills)
    {
        cards = new List<SkillCard>();
        foreach (var skillBase in skills)
        {
            cards.Add(new SkillCard(skillBase.ID));
        }
    }

    public SkillCard GetCard()
    {
        if (cards.Count == 0) {
            Console.WriteLine("������û�п����ˣ�");
            return null;
        }

        System.Random random = new System.Random();
        int index = random.Next(0, cards.Count);
        SkillCard card = cards[index];
        cards.RemoveAt(index);

        return card;
    }

    public void ReturnCard(SkillCard card) {
        cards.Add(card);
    }
}
