using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStageModel {

}

public class StageModel : Singleton<StageModel>, IStageModel
{

    public virtual void OnEnter()
    {

    }
    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public void FixedUpdate()
    {

    }

    public virtual void OnExit()
    {

    }

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
        return _currentStage;
    }
    
}
