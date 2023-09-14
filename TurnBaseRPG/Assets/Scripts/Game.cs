using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public void Awake()
    {
        ConfigType.DataManager.Instance.InitConfigs();
    }
    
}
