using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class Root : MonoBehaviour
{

    protected bool _destoryed;
    public virtual void Awake()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        RealTime.Update();
    }

    public static void Shutdown() {
        Application.Quit();
    }
}
