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
    //TODO:一场战斗一般由俩名玩家，俩个队伍组成
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

        //TODO:可能还会有死亡状态的首发单位，需要判断是否死亡，如果死亡的状态下默认换第一个角色出战
        if (CurrentPlayerUnit.IsDead) {
            CurrentPlayerUnit = PlayerParty.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyParty.First();

        CurrentPlayerBattleUnit = new BattleUnit(CurrentPlayerUnit);
        CurrentEnemyBattleUnit = new BattleUnit(CurrentEnemyUnit);

        SkillPools = new Dictionary<PokeGirl, SkillCardPool>();

        SendCards(CurrentPlayerBattleUnit);
        SendCards(CurrentEnemyBattleUnit);



        //TODO:战斗开始
        StartCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:设置UI播放入场表现
        BattlePanel.InitSkillList(CurrentPlayerBattleUnit);
        yield break;
    }

    //TODO:开始战斗时和每个回合结束时都会发卡

    public IEnumerator RoundEnd()
    {

        yield break;
    }

    public bool SendCards(BattleUnit unit)
    {
        //TODO:根据玩家当前单位所装备的技能发技能卡，并且数量与手中的卡需要对应，比如带了
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
