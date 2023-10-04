using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattlePerformable
{
    public void OnPerform(BattleUnit activeUnit,BattleUnit targetUnit);
}
