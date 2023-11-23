using System.Collections;
using System.Collections.Generic;
using ConfigType;
using Unity.VisualScripting;
using UnityEngine;

public class NPCBase : WorldObject,ICharacterBase, IHandleParty, IInteractive {
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

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            Debug.Log("玩家进入范围内");
            OnPlayerEnterTrigger();
        }
    }

    public virtual void OnPlayerEnterTrigger() {
        EventManager.Instance.TriggerEvent<IInteractive>(EventDef.PlayerEnterNPCTrigger,this);
    }

    public void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            Debug.Log("玩家离开范围内");
            OnPlayerExitTrigger();
        }
    }

    public virtual void OnPlayerExitTrigger() {
        EventManager.Instance.TriggerEvent<IInteractive>(EventDef.PlayerExitNPCTrigger,this);
    }

    public bool CanContact => true;

    public override void OnTrigger()
    {

    }

    public override void OnDestroy()
    {

    }

    public override void OnSpawn()
    {

    }
}
