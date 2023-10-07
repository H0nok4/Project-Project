using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using UI;
using UI.Battle;
using UnityEngine;

public enum BattleState
{
    BattleStart,
    SelectAction,
    PlayerTurn,
    EnemyTurn,
    RoundEnd,
    PlayerWin,
    PlayerLose,
}

public class BattleManager : MonoSingleton<BattleManager>
{
    //TODO:һ��ս��һ����������ң������������
    public BattlePanel BattlePanel;

    public Player Player;
    public NPCBase Enemy;

    public List<PokeGirl> PlayerParty;
    public List<PokeGirl> EnemyParty;

    public PokeGirl CurrentPlayerUnit;
    public PokeGirl CurrentEnemyUnit;

    public BattleUnit CurrentPlayerBattleUnit;
    public BattleUnit CurrentEnemyBattleUnit;

    public Dictionary<PokeGirl, SkillCardPool> SkillPools;

    public BattleState BattleState;


    protected override void Awake()
    {
        base.Awake();

    }

    public void SetBattle(Player player, NPCBase enemy)
    {
        BattlePanel = UIManager.Instance.Find<BattlePanel>();

        PlayerParty = player.BattleParty;
        EnemyParty = enemy.BattleParty;
        BattleState = BattleState.BattleStart;

        CurrentPlayerUnit = PlayerParty.Find((unit) => unit.IsFirst);
        if (CurrentPlayerUnit == null)
        {
            CurrentPlayerUnit = PlayerParty[0];
        }

        //TODO:���ܻ���������״̬���׷���λ����Ҫ�ж��Ƿ����������������״̬��Ĭ�ϻ���һ����ɫ��ս
        if (CurrentPlayerUnit.IsDead) {
            CurrentPlayerUnit = PlayerParty.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyParty.First();

        CurrentPlayerBattleUnit = new BattleUnit(CurrentPlayerUnit);
        CurrentEnemyBattleUnit = new BattleUnit(CurrentEnemyUnit);

        SkillPools = new Dictionary<PokeGirl, SkillCardPool>();

        SendCards(CurrentPlayerBattleUnit);
        SendCards(CurrentEnemyBattleUnit);



        //TODO:ս����ʼ
        StartCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:����UI�����볡����
        BattlePanel.InitSkillList(CurrentPlayerBattleUnit);
        yield break;
    }

    //TODO:��ʼս��ʱ��ÿ���غϽ���ʱ���ᷢ��

    public IEnumerator RoundEnd()
    {

        yield break;
    }

    public bool SendCards(BattleUnit unit)
    {
        //TODO:������ҵ�ǰ��λ��װ���ļ��ܷ����ܿ����������������еĿ���Ҫ��Ӧ���������
        if (!SkillPools.ContainsKey(unit.PokeGirl))
        {
            var skillPool = new SkillCardPool(unit.PokeGirl.EquipedSkills);
            SkillPools.Add(unit.PokeGirl, skillPool);
            for (int i = 0; i < 3; i++)
            {
                var skill = skillPool.GetCard();
                if (skill != null)
                {
                    unit.HandleSkillCards.Add(skill);
                }
                else
                {
                    return false;
                }
  
            }
        }
        else
        {
            var card = SkillPools[unit.PokeGirl].GetCard();
            if (card != null)
            {
                unit.HandleSkillCards.Add(card);
            }
            else
            {
                return false;
            }
        }

        return true;
    }

}
