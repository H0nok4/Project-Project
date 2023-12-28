using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoSingleton<InteractiveManager> {
    public List<IInteractive> InteractiveObject = new List<IInteractive>();

    public void Start() {
        EventManager.Instance.AddListener<IInteractive>(EventDef.PlayerEnterNPCTrigger,AddNPCInteract);
        EventManager.Instance.AddListener<IInteractive>(EventDef.PlayerExitNPCTrigger,RemoveNPCInteract);
    }

    private void AddNPCInteract(IInteractive obj) {
        if (InteractiveObject.Contains(obj)) {
            return;
        }
        InteractiveObject.Add(obj);
        Debug.Log($"增加一个互动弹窗,当前玩家靠近了{InteractiveObject.Count}个可互动物体");
        EventManager.Instance.TriggerEvent(EventDef.OnAddInteract);
    }

    private void RemoveNPCInteract(IInteractive obj) {
        if (!InteractiveObject.Contains(obj)) {
            return;
        }

        InteractiveObject.Remove(obj);
        Debug.Log($"移除一个互动弹窗,当前玩家靠近了{InteractiveObject.Count}个可互动物体");
        EventManager.Instance.TriggerEvent(EventDef.OnRemoveInteract);
    }

}
