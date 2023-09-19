using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    public void OnTrigger();

    public void OnDestroy();

    public void OnSpawn();
}
