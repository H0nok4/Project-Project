using System.Collections;
using System.Collections.Generic;
using Battle;
using UnityEngine;

public class BattleBaseUnit : IBattleUnit
{
    public virtual void OnDead()
    {
        
    }

    public virtual void ApplyDamage(int damageValue)
    {
        
    }

    public virtual void AfterDamage(bool killed, IBattleUnit damagedUnit)
    {
        
    }

    public virtual void AfterTakeDamaged(bool killed, IBattleUnit attackUnit)
    {

    }
}
