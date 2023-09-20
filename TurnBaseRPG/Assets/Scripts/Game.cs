using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void Awake()
    {
        ConfigType.DataManager.Instance.InitConfigs();
    }
    
}
