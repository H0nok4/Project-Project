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
        //TODO:更新当前的Stage
    }

    public void LateUpdate()
    {
        //TODO:在帧的末尾更新Stage
    }

    public void FixedUpdate()
    {
        //TODO:物理循环更新当前的Stage
    }

    public StageModel GetStageModel()
    {

    }
    
}
