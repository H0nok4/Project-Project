using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleUnit
{
    public void OnDead();

    public void Damage();

    public void AfterDamage(bool killed, IBattleUnit damagedUnit);

    public void AfterTakeDamaged(bool killed, IBattleUnit attackUnit);
}
