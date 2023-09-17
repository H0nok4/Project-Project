using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterBase
{
    public string Name { get; set; }

    public List<BattleUnit> BattleUnits { get; set; }
    
    public void OnDefeated();

    public void OnVictory();

    public void OnBattleStart();

    public void OnBattleEnd();

}
