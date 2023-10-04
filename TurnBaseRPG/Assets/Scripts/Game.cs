using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UIPanel Test_BattlePanel;
    public void Awake()
    {
        InitGame();
    }

    private void InitGame()
    {
        //TODO:初始化游戏各个模块
        ConfigType.DataManager.Instance.InitConfigs();
        UIManager.Instance.Init();

        //TODO:测试
        UIManager.Instance.Show(Test_BattlePanel);
    }

}
