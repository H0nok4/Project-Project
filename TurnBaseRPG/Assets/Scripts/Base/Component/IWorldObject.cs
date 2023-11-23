using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldObject
{
    public void OnTrigger();

    public void OnDestroy();

    public void OnSpawn();
}
