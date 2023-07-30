using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : Singlaton<DataManager>
{
    public const string DataPath = "Resources/Config";

    public void Init()
    {
        //TODO:加载数据,读取数据路径下所有的文件夹下的ScriptableObject
        
    }

    public void LoadData()
    {

    }
}
