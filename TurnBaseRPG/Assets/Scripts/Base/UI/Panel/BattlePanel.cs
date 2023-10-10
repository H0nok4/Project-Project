using System.Collections;
using System.Collections.Generic;
using UI.Battle;
using UnityEngine;
using UnityEngine.UI;


namespace UI.Battle
{
    public partial class BattlePanel : UIPanel {
        public BattleSelector BattleSelector;
        public BattleTopBar PlayerTopBar;
        public BattleTopBar EnemyTopBar;
        public ButtonCollection ButtonCollection;
        public ComBattleUnit PlayerBattleUnit;
        public ComBattleUnit EnemyBattleUnit;
        public override void InitInstance() {
            BattleSelector = (BattleSelector)GetUIComponentAtChildIndex(1);
            ButtonCollection = (ButtonCollection)GetUIComponentAtChildIndex(3);
            PlayerBattleUnit = (ComBattleUnit)GetUIComponentAtChildIndex(4);
            EnemyBattleUnit = (ComBattleUnit)GetUIComponentAtChildIndex(5);
            PlayerTopBar = (BattleTopBar)GetUIComponentAtChildIndex(7);
            EnemyTopBar = (BattleTopBar)GetUIComponentAtChildIndex(8);
        }
    }

    public partial class BattlePanel : UIPanel {

        public override void OnShow() {

        }
        public override void OnInit() {
            Debug.Log("初始化BattlePanel");
            
        }

        public void InitBattleUnitImage(BattleUnit player,BattleUnit enemy)
        {
            //TODO:目前没有图片，先不刷新
            //PlayerBattleUnit.UnitImage.sprite = 
            //EnemyBattleUnit.UnitImage.sprite = 
            Debug.Log("初始化BattleUnitImage");
        }

        public void InitTopBar(BattleUnit player, BattleUnit enemy)
        {
            PlayerTopBar.InitTopBar(player);
            EnemyTopBar.InitTopBar(enemy);
            Debug.Log("初始化TopBar");
        }

        public void InitSkillList(BattleUnit playerUnit)
        {
            BattleSelector.ListSkillMove.ChildCount = playerUnit.HandleSkillCards.Count;
            for (int i = 0; i < playerUnit.HandleSkillCards.Count; i++)
            {
                var comSkillCard = (ComSkillMove)BattleSelector.ListSkillMove.ChildList[i];
                comSkillCard.Refresh(playerUnit.HandleSkillCards[i]);
            }
        }
    }

}
