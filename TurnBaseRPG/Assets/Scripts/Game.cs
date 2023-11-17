using System.Collections;
using System.Collections.Generic;
using Battle;
using UI;
using UnityEngine;
using UnityEngine.Playables;

public class Game : MonoBehaviour
{
    public UIPanel Test_BattlePanel;
    public Player Player;
    public NPCBase TestEnemy;

    public BattleUnitGO PlayBattleGO;
    public BattleUnitGO EnemyBattleGO;
    public void Awake()
    {
        InitGame();
    }

    public void Update()
    {
        StageController.Instance.Update();
    }

    public void FixedUpdate()
    {
        StageController.Instance.FixedUpdate();
    }

    public void LateUpdate()
    {
        StageController.Instance.LateUpdate();
    }

    private void InitGame()
    {
        Application.targetFrameRate = 60;
        //TODO:初始化游戏各个模块
        ConfigType.DataManager.Instance.InitConfigs();
        ConfigType.DataManager.Instance.InitResources();
        UIManager.Instance.Init();

        //TODO:测试
        UIManager.Instance.Show(Test_BattlePanel);
        Player = new Player();
        Player.BattleParty.Add(new PokeGirl(1,1));
        TestEnemy = new NPCTest(){ID = 1};

        StageController.Instance.SetCurrentStage(BattleStage.Instance);
        BattleStage.Instance.CurrentPlayerUnitGO = PlayBattleGO;
        BattleStage.Instance.CurrentEnemyUnitGO = EnemyBattleGO;
        PlayBattleGO.Init();
        EnemyBattleGO.Init();
        BattleStage.Instance.SetBattle(Player,TestEnemy);
    }

}
