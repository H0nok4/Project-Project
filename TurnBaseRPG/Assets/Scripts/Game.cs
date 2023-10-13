using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UIPanel Test_BattlePanel;
    public Player Player;
    public NPCBase TestEnemy;
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
        Player = new Player();
        Player.BattleParty.Add(new PokeGirl(1,1));
        TestEnemy = new NPCTest(1);
        StageController.Instance.SetCurrentStage(BattleStage.Instance);
        BattleStage.Instance.SetBattle(Player,TestEnemy);

    }

}
