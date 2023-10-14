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
    }

    public void RefreshSkillList()
    {
        BattlePanel.RefreshSkillList(Stage.CurrentPlayerBattleUnit);
    }

    public void RefreshTopBar()
    {
        //BattlePanel.RefreshTopBar();
    }

}
