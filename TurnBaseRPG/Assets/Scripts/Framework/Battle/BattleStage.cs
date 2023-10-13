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
    //TODO:以后应该会有播剧情阶段，可能会随时插入战斗
    StartNewTurn,
    CalculateSpeed,
    RoundStart,
    DrawCard,//双方抽卡环节
    PlayerTurn,
    PerformPlayerAction,
    EnemyTurn,
    PerformEnemyAction,
    RoundEnd,
    PlayerWin,
    PlayerLose,
}

public class BattleStage : Singleton<BattleStage>,IStageModel
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

    public int Round;

    public bool LeftEnd;
    public bool RightEnd;

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


    public void OnEnter()
    {
        
    }

    public void Update()
    {
        if (!_battleStarted)
        {
            //TODO:战斗循环，通过当前的状态
            return;
        }

        if (BattleState == BattleState.CalculateSpeed)
        {
            //TODO:计算双方的速度，决定第一回合谁先动手
        }
    }

    public void LateUpdate()
    {

    }

    public void FixedUpdate()
    {

    }

    public void OnExit()
    {

    }

    public void SetBattle(Player player, NPCBase enemy)
    {

        BattlePanel = UIManager.Instance.Find<BattlePanel>();

        PlayerParty = player.BattleParty;
        EnemyParty = enemy.BattleParty;

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





        //TODO:战斗开始
        CoroutineManager.Instance.CreateCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattleState = BattleState.BattleStart;
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:设置UI播放入场表现
        BattlePanel.RefreshSkillList(CurrentPlayerBattleUnit);

        SendCards(CurrentPlayerBattleUnit, 3);
        SendCards(CurrentEnemyBattleUnit, 3);

        BattleState = BattleState.CalculateSpeed;
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
