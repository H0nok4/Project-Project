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
        //TODO:��ʼ����Ϸ����ģ��
        ConfigType.DataManager.Instance.InitConfigs();
    }
    
}
