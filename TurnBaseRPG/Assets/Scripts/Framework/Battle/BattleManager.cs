using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    //TODO:一场战斗一般由俩名玩家，俩个队伍组成
    public PlayerBase Player;
    public NPCBase Enemy;

    public List<BattleUnit> PlayerUnit;
    public List<BattleUnit> EnemyUnit;

    public BattleUnit CurrentPlayerUnit;
    public BattleUnit CurrentEnemyUnit;

    public void SetBattle(PlayerBase player, NPCBase enemy)
    {
        PlayerUnit = player.BattleUnits;
        EnemyUnit = enemy.BattleUnits;

        //TODO:战斗开始
        BattleStart();
    }

    public void BattleStart()
    {
        CurrentPlayerUnit = PlayerUnit.Find((unit) => unit.IsFirst);
        //TODO:可能还会有死亡状态的首发单位，需要判断是否死亡，如果死亡的状态下默认换第一个角色出战
        if (CurrentPlayerUnit.IsDead)
        {
            CurrentPlayerUnit = PlayerUnit.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyUnit.First();
    }
}
