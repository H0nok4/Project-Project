using System.Collections;
using System.Collections.Generic;
using Battle;
using UnityEngine;

public class BattleBaseUnit : IBattleUnit
{
    public virtual void OnDead()
    {
        
    }

    public virtual void Damage(DamageDetail detail)
    {
        
    }

    public virtual void AfterDamage(bool killed, IBattleUnit damagedUnit)
    {
        
    }

    public virtual void AfterTakeDamaged(bool killed, IBattleUnit attackUnit)
    {

    }
}
