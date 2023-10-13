using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStageModel
{
    public void OnEnter();

    public void Update();

    public void LateUpdate();

    public void FixedUpdate();
    public void OnExit();
}

public class StageController : Singleton<StageController> 
{
    private IStageModel _currentStage;

    public void SetCurrentStage(IStageModel model)
    {
        if (_currentStage != null)
        {
            _currentStage.OnExit();
        }

        _currentStage = model;

        _currentStage.OnEnter();
    }

    public void Update()
    {
        //TODO:���µ�ǰ��Stage
        _currentStage.Update();
    }

    public void LateUpdate()
    {
        //TODO:��֡��ĩβ����Stage

        _currentStage.LateUpdate();
    }

    public void FixedUpdate()
    {
        //TODO:����ѭ�����µ�ǰ��Stage

        _currentStage.FixedUpdate();
    }

    public IStageModel GetStageModel()
    {
        return _currentStage;
    }
    
}
