using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    //TODO:һ��ս��һ����������ң������������
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

        //TODO:ս����ʼ
        BattleStart();
    }

    public void BattleStart()
    {
        CurrentPlayerUnit = PlayerUnit.Find((unit) => unit.IsFirst);
        //TODO:���ܻ���������״̬���׷���λ����Ҫ�ж��Ƿ����������������״̬��Ĭ�ϻ���һ����ɫ��ս
        if (CurrentPlayerUnit.IsDead)
        {
            CurrentPlayerUnit = PlayerUnit.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyUnit.First();
    }
}
