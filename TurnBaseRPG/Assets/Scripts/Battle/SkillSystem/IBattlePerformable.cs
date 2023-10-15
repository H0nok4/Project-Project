using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattlePerformable
{
    public IEnumerator OnPerform(BattleUnit activeUnit,BattleUnit targetUnit);
}
