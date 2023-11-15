using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class NPCBase : WorldObject,ICharacterBase, IHandleParty {
    public int ID { get; }
    public string Name { get; set; }
    public NPCBaseDefine Define => DataManager.Instance.GetNPCBaseDefineByID(ID);
    public List<PokeGirl> BattleParty { get; set; }
    public NPCBase(int id)
    {
        ID = id;
        BattleParty = new List<PokeGirl>();
        for (int i = 0; i < Define.BattlePartyID.Count; i++)
        {
            BattleParty.Add(new PokeGirl(Define.BattlePartyID[i], Define.BattlePartyLevel[i]));
        }
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
