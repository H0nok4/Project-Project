using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ICharacterBase
{
    public string Name { get; set; }
    public List<BattleUnit> BattleUnits { get; set; } = new List<BattleUnit>();
    public void OnDefeated()
    {
        //TODO:战败了进入战败流程,可能是触发战败事件，事件结束后昏迷回到最近一次注册的安全点
    }

    public void OnVictory()
    {
        //TODO:胜利了进入胜利流程
    }

    public void OnBattleStart()
    {
        //TODO:可能有什么道具或者事件会在战斗开始时触发
    }

    public void OnBattleEnd()
    {
        //TODO:同理，可能有什么道具或者事件会在战斗结束时触发
    }
}
