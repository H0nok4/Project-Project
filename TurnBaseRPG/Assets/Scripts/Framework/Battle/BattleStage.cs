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
    //TODO:一场战斗一般由俩名玩家，俩个队伍组成
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
                Debug.Log("开启战斗！");
            }
            else
            {
                Debug.Log("结束战斗！");
            }
        }
    }


    public override void Update()
    {
        if (_battleStarted)
        {
            //TODO:战斗循环，通过当前的状态

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

        //TODO:可能还会有死亡状态的首发单位，需要判断是否死亡，如果死亡的状态下默认换第一个角色出战
        if (CurrentPlayerUnit.IsDead) {
            CurrentPlayerUnit = PlayerParty.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyParty.First();

        CurrentPlayerBattleUnit = new BattleUnit(CurrentPlayerUnit);
        CurrentEnemyBattleUnit = new BattleUnit(CurrentEnemyUnit);

        SkillPools = new Dictionary<PokeGirl, SkillCardPool>();

        SendCards(CurrentPlayerBattleUnit,3);
        SendCards(CurrentEnemyBattleUnit,3);



        //TODO:战斗开始
        CoroutineManager.Instance.StartCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:设置UI播放入场表现
        BattlePanel.RefreshSkillList(CurrentPlayerBattleUnit);
        yield break;
    }

    //TODO:开始战斗时和每个回合结束时都会发卡

    public IEnumerator RoundEnd()
    {

        yield break;
    }

    public bool SendCards(BattleUnit unit,int cardNum)
    {
        //TODO:根据玩家当前单位所装备的技能发技能卡，并且数量与手中的卡需要对应，比如带了
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
