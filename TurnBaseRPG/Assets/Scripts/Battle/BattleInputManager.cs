using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputContext
{
    public enum InputType
    {
        SelectSkill,
        SelectItem,
        SelectSwitchTarget,
        SelectRun,
        SelectEndTurn
    }

    public InputType Type;
    public SkillCard SkillCard;
    //TODO:其他的信息
}

public class BattlePlayerInputManager
{
    public BattleStage Stage;

    public bool SelectedSkill;
    public SkillCard skillCard;

    public bool SelectedItem;
    //TODO:道具信息

    public bool SelectedSwitchTarget;

    public bool SelectedRun;

    public bool SelectEndTurn;
    //TODO:目标信息
    public BattlePlayerInputManager(BattleStage stage)
    {
        Stage = stage;
        EventManager.Instance.AddListener<SkillCard>(EventDef.OnClickBattleCard,OnClickBattleCard);
        EventManager.Instance.AddListener(EventDef.OnClickBattleEndTurnButton, OnClickBattleEndTurnButton);
    }

    private void OnClickBattleEndTurnButton()
    {
        if (Stage.BattleState != BattleState.PlayerTurn)
        {
            return;
        }

        SelectEndTurn = true;
    }

    public void OnClickBattleCard(SkillCard card)
    {
        Debug.Log("触发了点击了技能卡事件");
        if (Stage.BattleState != BattleState.PlayerTurn)
        {
            Debug.Log("当前不是玩家回合,跳出");
            return;
        }

        SelectedSkill = true;
        skillCard = card;
    }

    public PlayerInputContext CheckInput()
    {
        PlayerInputContext context = null;
        if (SelectedSkill)
        {
            context = new PlayerInputContext() { Type = PlayerInputContext.InputType.SelectSkill, SkillCard = skillCard };
        }else if (SelectEndTurn)
        {
            context = new PlayerInputContext() { Type = PlayerInputContext.InputType.SelectEndTurn };
        }

        SelectedSkill = false;
        skillCard = null;

        SelectedItem = false;

        SelectedSwitchTarget = false;

        SelectedRun = false;

        SelectEndTurn = false;
        return context;
    }

}
