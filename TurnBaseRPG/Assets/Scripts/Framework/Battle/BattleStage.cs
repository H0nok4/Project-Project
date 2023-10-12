using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using UI;
using UI.Battle;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

public class BattleStage : StageModel
{
    //TODO:һ��ս��һ����������ң������������
    private bool _battleStarted;

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

    public bool BattleStarted
    {
        get => _battleStarted;
        set
        {
            _battleStarted = value;

            if (_battleStarted)
            {
                Debug.Log("����ս����");
            }
            else
            {
                Debug.Log("����ս����");
            }
        }
    }


    public override void Update()
    {
        if (_battleStarted)
        {
            //TODO:ս��ѭ����ͨ����ǰ��״̬

        }
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

        SendCards(CurrentPlayerBattleUnit,3);
        SendCards(CurrentEnemyBattleUnit,3);



        //TODO:ս����ʼ
        CoroutineManager.Instance.StartCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:����UI�����볡����
        BattlePanel.RefreshSkillList(CurrentPlayerBattleUnit);
        yield break;
    }

    //TODO:��ʼս��ʱ��ÿ���غϽ���ʱ���ᷢ��

    public IEnumerator RoundEnd()
    {

        yield break;
    }

    public bool SendCards(BattleUnit unit,int cardNum)
    {
        //TODO:������ҵ�ǰ��λ��װ���ļ��ܷ����ܿ����������������еĿ���Ҫ��Ӧ���������
        if (!SkillPools.ContainsKey(unit.PokeGirl))
        {
            var skillPool = new SkillCardPool(unit.PokeGirl.EquipedSkills);
            SkillPools.Add(unit.PokeGirl, skillPool);
            for (int i = 0; i < cardNum; i++)
            {
                var skill = skillPool.GetCard();
                if (skill != null)
                {
                    unit.AddSkillCard(skill);
                }
                else
                {
                    return false;
                }
  
            }
        }
        else
        {
            for (int i = 0; i < cardNum; i++)
            {
                var card = SkillPools[unit.PokeGirl].GetCard();
                if (card != null) {
                    unit.AddSkillCard(card);
                }
                else {
                    return false;
                }
            }

        }

        return true;
    }

}
