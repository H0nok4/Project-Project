using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageModel
{

}

public class StageController : Singleton<StageController> 
{
    private StageModel _currentStage;

    public void Update()
    {
        //TODO:���µ�ǰ��Stage
    }

    public void LateUpdate()
    {
        //TODO:��֡��ĩβ����Stage
    }

    public void FixedUpdate()
    {
        //TODO:����ѭ�����µ�ǰ��Stage
    }

    public StageModel GetStageModel()
    {

    }
    
}
