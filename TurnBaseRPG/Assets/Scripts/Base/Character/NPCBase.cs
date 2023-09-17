using System.Collections;
using System.Collections.Generic;
using ConfigType;
using UnityEngine;

public class NPCBase : MonoBehaviour , ICharacterBase
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

    public void OnDefeated()
    {
        
    }

    public void OnVictory()
    {

    }

    public void OnBattleStart()
    {

    }

    public void OnBattleEnd()
    {

    }
}
