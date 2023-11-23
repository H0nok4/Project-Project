using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoSingleton<InteractiveManager> {
    public List<IInteractive> InteractiveObject = new List<IInteractive>();

    public void Start() {

    }
}
