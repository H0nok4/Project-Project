using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void Awake()
    {

    }

    private void InitGame()
    {
        //TODO:初始化游戏各个模块
        ConfigType.DataManager.Instance.InitConfigs();
    }
    
}
