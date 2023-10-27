using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BattleEventBase 
{
    public delegate void EventCallback(BattleEventBase evt);
}
