using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldObject : IInteractive
{
    public virtual void OnTrigger() {
        
    }

    public virtual void OnDestroy() {

    }

    public virtual void OnSpawn() {

    }
}
