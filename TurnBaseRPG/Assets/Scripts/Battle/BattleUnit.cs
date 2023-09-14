using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:当前战斗的单位
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// 当前单位
    /// </summary>
    public PokeGirl PokeGirl;

    /// <summary>
    /// 当前是否为出战单位
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// 当前单位是否为阵亡状态
    /// </summary>
    public bool IsDead;

    /// <summary>
    /// 当前的生命值
    /// </summary>
    public int CurrentHp;

    public BattleUnit(PokeGirl pokeGirl)
    {
        PokeGirl = pokeGirl;
    }

    
}
