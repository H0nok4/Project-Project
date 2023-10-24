using System.Collections;
using System.Collections.Generic;
using UI.Battle;
using UnityEngine;

public class BattleUIManager
{
    public BattleStage Stage;
    public BattlePanel BattlePanel;

    public BattleUIManager(BattleStage stage,BattlePanel battlePanel)
    {
        Stage = stage;
        BattlePanel = battlePanel;
    }

    public void InitBattle()
    {
        BattlePanel.InitBattleUnitImage(Stage.CurrentPlayerBattleUnit, Stage.CurrentEnemyBattleUnit);
        BattlePanel.InitTopBar(Stage.CurrentPlayerBattleUnit, Stage.CurrentEnemyBattleUnit);
        BattlePanel.UpdateBattleRound(Stage.Round);
    }

    public void RefreshSkillList()
    {
        BattlePanel.RefreshSkillList(Stage.CurrentPlayerBattleUnit);
    }

    public void SetPlayerHP(BattleUnit unit)
    {
        if (unit == null)
        {
            return;
        }

        BattlePanel.PlayerTopBar.HPBar.SetValue(unit.CurrentHP / unit.MaxHP);
    }

    public void SetPlayerHP(float decrease,BattleUnit playerUnit) {
        var value = BattlePanel.PlayerTopBar.HPBar.Value - (decrease / playerUnit.MaxHP);
        BattlePanel.PlayerTopBar.HPBar.RefreshHP(value,playerUnit.MaxHP);
    }

    public void SetEnemyHP(float decrease, BattleUnit enemyUnit) {
        var value = BattlePanel.EnemyTopBar.HPBar.Value - (decrease / enemyUnit.MaxHP);
        //TODO:有BUG
        BattlePanel.EnemyTopBar.HPBar.RefreshHP(value, enemyUnit.MaxHP);
    }

    public void SetEnemyHP(BattleUnit unit)
    {
        if (unit == null)
        {
            return;
        }
        BattlePanel.EnemyTopBar.HPBar.SetValue(unit.CurrentHP / unit.MaxHP);
    }

    public void SetPlayerSkillPoint(BattleUnit unit)
    {
        if (unit == null)
        {
            return;
        }

        BattlePanel.PlayerTopBar.SetSkillPoint(unit.SkillPoint, unit.MaxSkillPoint);
    }

    public void SetEnemySkillPoint(BattleUnit unit)
    {
        if (unit == null)
        {
            return;
        }

        BattlePanel.EnemyTopBar.SetSkillPoint(unit.SkillPoint,unit.MaxSkillPoint);
    }

    public void OnBattleRoundEnd()
    {

    }

    public void OnBattleRoundStart()
    {
        BattlePanel.UpdateBattleRound(Stage.Round);
    }


}
