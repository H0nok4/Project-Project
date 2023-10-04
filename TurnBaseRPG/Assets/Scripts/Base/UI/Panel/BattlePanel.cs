using System.Collections;
using System.Collections.Generic;
using UI.Battle;
using UnityEngine;


namespace UI.Battle
{
    public partial class BattlePanel : UIPanel {
        public BattleSelector BattleSelector;
        public BattleTopBar PlayerTopBar;
        public BattleTopBar EnemyTopBar;
        public ButtonCollection ButtonCollection;
        public override void InitInstance() {
            BattleSelector = (BattleSelector)GetUIComponentAtChildIndex(1);
            ButtonCollection = (ButtonCollection)GetUIComponentAtChildIndex(3);
            PlayerTopBar = (BattleTopBar)GetUIComponentAtChildIndex(7);
            EnemyTopBar = (BattleTopBar)GetUIComponentAtChildIndex(8);
        }
    }

    public partial class BattlePanel : UIPanel {

        public override void OnShow() {

        }
        public override void OnInit() {
            Debug.Log("≥ı ºªØBattlePanel");
            BattleSelector.ListSkillMove.ChildCount = 5;
        }
    }

}
