using System.Collections;
using System.Collections.Generic;
using ConfigType;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBase : WorldObject,ICharacterBase, IHandleParty {
    [SerializeField] 
    public int ID;
    public string Name { get; set; }
    public NPCBaseDefine Define => DataManager.Instance.GetNPCBaseDefineByID(ID);
    public List<PokeGirl> BattleParty { get; set; }

    public Collider2D TriggerCollider2D;

    public override void InitObject() {
        BattleParty = new List<PokeGirl>();
        for (int i = 0; i < Define.BattlePartyID.Count; i++) {
            BattleParty.Add(new PokeGirl(Define.BattlePartyID[i], Define.BattlePartyLevel[i]));
        }

        TriggerCollider2D = transform.GetComponent<Collider2D>();
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

    public virtual void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            Debug.Log("玩家进入范围内");
        }

        ;
        
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
