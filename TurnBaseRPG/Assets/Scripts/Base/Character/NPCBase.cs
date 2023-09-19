using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class NPCBase : ICharacterBase, IHandleBattleUnit, IInteractive
{
    public int ID { get; }
    public string Name { get; set; }
    public ConfigType.NPCBaseDefine Define => DataManager.Instance.GetNPCBaseDefineByID(ID);
    public List<BattleUnit> BattleUnits { get; set; }
    public NPCBase(int id)
    {
        ID = id;
        BattleUnits = new List<BattleUnit>();
    }

    public virtual void OnDefeated()
    {
        
    }

    public virtual void OnVictory()
    {

    }

    public virtual void OnBattleStart()
    {

    }

    public virtual void OnBattleEnd()
    {

    }

    public virtual void OnTrigger()
    {

    }

    public virtual void OnDestroy()
    {

    }

    public virtual void OnSpawn()
    {

    }
}
