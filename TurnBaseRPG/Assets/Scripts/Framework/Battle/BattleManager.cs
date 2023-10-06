using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UI;
using UI.Battle;
using UnityEngine;

public enum BattleState
{
    BattleStart,
    SelectAction,
    PlayerTurn,
    EnemyTurn,
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

        //TODO:ս����ʼ
        StartCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattlePanel.InitBattleUnitImage(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(CurrentPlayerBattleUnit,CurrentEnemyBattleUnit);
        //TODO:����UI�����볡����
        
        yield break;
    }

}
