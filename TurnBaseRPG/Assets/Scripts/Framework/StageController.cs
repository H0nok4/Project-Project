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
        return _currentStage;
    }
    
}
