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
        //TODO:��ʼ����Ϸ����ģ��
        ConfigType.DataManager.Instance.InitConfigs();
        UIManager.Instance.Init();

        //TODO:����
        UIManager.Instance.Show(Test_BattlePanel);
    }

}
