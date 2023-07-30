using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBaseUnit : IBattleUnit
{
    public virtual void OnDead()
    {
        
    }

    public virtual void Damage()
    {
        
    }

    public virtual void AfterDamage(bool killed, IBattleUnit damagedUnit)
    {
        
    }

    public virtual void AfterTakeDamaged(bool killed, IBattleUnit attackUnit)
    {

    }
}
