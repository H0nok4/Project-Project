using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:��ǰս���ĵ�λ
public class BattleUnit : BattleBaseUnit
{
    /// <summary>
    /// ��ǰ��λ
    /// </summary>
    public PokeGirl PokeGirl;

    /// <summary>
    /// ��ǰ�Ƿ�Ϊ��ս��λ
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// ��ǰ��λ�Ƿ�Ϊ����״̬
    /// </summary>
    public bool IsDead;

    /// <summary>
    /// ��ǰ������ֵ
    /// </summary>
    public int CurrentHp;

    public BattleUnit(PokeGirl pokeGirl)
    {
        PokeGirl = pokeGirl;
    }

    
}
