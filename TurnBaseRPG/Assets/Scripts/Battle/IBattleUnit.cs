using System.Collections;
using System.Collections.Generic;
using Battle;
using UnityEngine;

public interface IBattleUnit
{
    public void OnDead();

    public void ApplyDamage(DamageDetail detail);

    public void AfterDamage(bool killed, IBattleUnit damagedUnit);

    public void AfterTakeDamaged(bool killed, IBattleUnit attackUnit);
}
