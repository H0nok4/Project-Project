using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UI;
using UI.Battle;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum BattleState
{
    BattleStart,
    //TODO:�Ժ�Ӧ�û��в�����׶Σ����ܻ���ʱ����ս��
    FirstRound,
    CalculateSpeed,
    RoundStart,
//    DrawCard,//˫���鿨����
    PlayerTurn,
    PerformPlayerAction,
    PlayerTurnEnd,
    EnemyTurn,
    PerformEnemyAction,
    EnemyTurnEnd,
    RoundEnd,
    PlayerDeadSwitch,
    EnemyDeadSwitch,
    PlayerWin,
    PlayerLose,
}

public class BattleStage : Singleton<BattleStage>,IStageModel
{
    //TODO:һ��ս��һ����������ң������������
    private bool _battleStarted;

    //public BattlePanel BattlePanel;
    public BattleUIManager BattleUIManager;
    public BattlePlayerInputManager InputManager;

    public Player Player;
    public NPCBase Enemy;

    public List<PokeGirl> PlayerParty;
    public List<PokeGirl> EnemyParty;

    public PokeGirl CurrentPlayerUnit;
    public PokeGirl CurrentEnemyUnit;

    public BattleUnit CurrentPlayerBattleUnit;
    public BattleUnit CurrentEnemyBattleUnit;

    public Dictionary<PokeGirl, SkillCardPool> SkillPools;

    public BattleState BattleState;

    public int Round;

    public bool LeftEnd;
    public bool RightEnd;

    public bool BattleStarted
    {
        get => _battleStarted;
        set
        {
            _battleStarted = value;

            if (_battleStarted)
            {
                Debug.Log("����ս����");
            }
            else
            {
                Debug.Log("����ս����");
            }
        }
    }


    public void OnEnter()
    {
        BattleStarted = true;
    }

    public void Update()
    {
        if (!_battleStarted)
        {
            //TODO:ս��ѭ����ͨ����ǰ��״̬
            return;
        }

        if (BattleState == BattleState.FirstRound)
        {
            StartNewRound(true);
        }else if (BattleState == BattleState.RoundStart)
        {
            StartNewRound();
        }
        else if (BattleState == BattleState.CalculateSpeed)
        {
            //TODO:����˫�����ٶȣ�������һ�غ�˭�ȶ���
            CalculateSpeed();
        }else if (BattleState == BattleState.PlayerTurn)
        {
            //TODO:�ȴ��������ָ��
            CheckPlayerInput();
        }else if (BattleState == BattleState.PerformPlayerAction)
        {
            //TODO:�������ѡ����ж�������ʹ�ÿ��ƣ��л���λ��ʹ�õ��ߵȣ����ű���
        }
        else if (BattleState == BattleState.PlayerTurnEnd) {
            //��һغϽ���
            CheckPlayerTurnEnd();
        }
        else if (BattleState == BattleState.EnemyTurn)
        {
            //TODO:AI�ж�
            RunAITurn();
        }else if (BattleState == BattleState.PerformEnemyAction)
        {
            //TODO:����AIѡ����ж�������ʹ�ÿ��ƣ��л���λ��ʹ�õ��ߵȣ����ű���
        }
        else if (BattleState == BattleState.EnemyTurnEnd)
        {
            CheckEnemyTurnEnd();
        }
        else if (BattleState == BattleState.RoundEnd)
        {
            //TODO:������ÿ�غϽ����˺���BUFF��Ȼ�����BUFF��ʱ����1�غ�
            OnRoundEnd();
        }


    }

    private void OnRoundEnd()
    {
        Debug.Log("�غϽ���");
        //TODO:
        LeftEnd = false;
        RightEnd = false;

        //TODO:

        BattleState = BattleState.RoundStart;

        BattleUIManager.OnBattleRoundEnd();
    }

    private bool CheckHasDeadUnit()
    {
        //ÿ���ж��궼��Ҫ�ж����ߵĴ����������ܱ������˻��߱�Debuff���Լ�������֮���
        if (CurrentPlayerBattleUnit.IsDead)
        {
            if (!PlayerParty.Exists((unit)=>! unit.IsDead))
            {
                //TODO:������е�λ����������ս��
                BattleState = BattleState.PlayerLose;
            }
            else
            {
                BattleState = BattleState.PlayerDeadSwitch;
            }

            return true;
        }

        if (CurrentEnemyBattleUnit.IsDead)
        {
            if (EnemyParty.Exists((unit) => !unit.IsDead))
            {
                BattleState = BattleState.PlayerWin;
            }
            else
            {
                BattleState = BattleState.EnemyDeadSwitch;
            }

            return true;
        }

        return false;
    }

    private void CheckEnemyTurnEnd()
    {
        if (RightEnd && LeftEnd) {
            Debug.Log("�����������ж�������غϽ���");
            BattleState = BattleState.RoundEnd;
            return;
        }

        if (LeftEnd) {
            Debug.Log("����Ѿ������ж����ٴν�������ж�");
            BattleState = global::BattleState.EnemyTurn;
            return;
        }

        if (!CheckHasDeadUnit())
        {
            Debug.Log("û�������Ľ�ɫ��������һغ�");
            BattleState = BattleState.PlayerTurn;
            return;
        }

    }

    private void CheckPlayerTurnEnd()
    {
        if (RightEnd && LeftEnd)
        {
            Debug.Log("�����������ж�������غϽ���");
            BattleState = BattleState.RoundEnd;
            return;
        }

        if (RightEnd)
        {
            Debug.Log("�����Ѿ������ж����ٴν�������ж�");
            BattleState = global::BattleState.PlayerTurn;
            return;
        }

        if (!CheckHasDeadUnit()) {
            Debug.Log("û�������Ľ�ɫ��������˻غ�");
            BattleState = BattleState.EnemyTurn;
            return;
        }
     
    }

    private void RunAITurn()
    {
        if (RightEnd)
        {
            //�Ѿ�����غϽ����ˣ����ٽ�����˻غ�
            BattleState = BattleState.EnemyTurnEnd;
            return;
        }
        
        //TODO:�����ã�AI���Խ����غ�
        Debug.Log("AI�����غ�");
        RightEnd = true;

        BattleState = BattleState.EnemyTurnEnd;
    }

    private void CheckPlayerInput()
    {
        if (LeftEnd)
        {
            BattleState = BattleState.PlayerTurnEnd;
        }
        var context = InputManager.CheckInput();
        if (context == null)
        {
            return;
        }

        if (context.Type == PlayerInputContext.InputType.SelectSkill)
        {
            //TODO:�ݳ���Ӧ�ļ���
            OnPlayerSelectSkill(context.SkillCard);
        }else if (context.Type == PlayerInputContext.InputType.SelectEndTurn)
        {
            //�غϽ�����
            LeftEnd = true;
            BattleState = BattleState.PlayerTurnEnd;
        }
    }

    private void OnPlayerSelectSkill(SkillCard skillCard)
    {
        BattleState = BattleState.PerformPlayerAction;
        CurrentPlayerBattleUnit.HandleSkillCards.Remove(skillCard);
        SkillPools[CurrentPlayerUnit].ReturnCard(skillCard);
        BattleUIManager.RefreshSkillList();
        CoroutineManager.Instance.CreateCoroutine(OnPlayerUseSkill(skillCard));
    }

    private IEnumerator OnPlayerUseSkill(SkillCard skillCard)
    {
        Debug.Log($"���ѡ���˼��ܣ���������Ϊ��{skillCard.Define.SkillName}");
        Debug.Log("��ʼ���ż��ܱ��֡���");
        yield return skillCard.OnPerform(CurrentPlayerBattleUnit, CurrentEnemyBattleUnit);
        Debug.Log("���ܱ��ֲ��Ž���");

        BattleState = BattleState.PlayerTurnEnd;
    }


    private void StartNewRound(bool firstRound = false)
    {
        
        if (firstRound)
        {
            Round = 1;
            Debug.Log("������һ���غ�");
            //TODO:��һ�غϣ��鿨Ҫ��3��
            SendCards(CurrentPlayerBattleUnit, 3);
            SendCards(CurrentEnemyBattleUnit, 3);
        }
        else
        {
            Round++;
            Debug.Log($"�����»غϣ���ǰ�غ�����{Round}");
            //TODO:�����غϣ��鿨ֻ�ó�1��
            SendCards(CurrentPlayerBattleUnit, 1);
            SendCards(CurrentEnemyBattleUnit, 1);
        }

        BattleUIManager.OnBattleRoundStart();

        //TODO:��Ҫ�ָ����ܵ�
        BattleState = BattleState.CalculateSpeed;

    }

    private void CalculateSpeed()
    {
        //TODO:��ʱ�û����ٶȴ�����
        if (CurrentPlayerBattleUnit.PokeGirl.SpeedBase >= CurrentEnemyBattleUnit.PokeGirl.SpeedBase)
        {
            Debug.Log("�����ٶȺ��������");
            BattleState = BattleState.PlayerTurn;
        }
        else
        {
            Debug.Log("�����ٶȺ󣬵�������");
            BattleState = BattleState.EnemyTurn;
        }


    }

    public void LateUpdate()
    {
        //TODO:ˢ��UI��

    }

    private void RefreshBattleUI()
    {
        BattleUIManager.RefreshSkillList();
    }

    public void FixedUpdate()
    {

    }

    public void OnExit()
    {
        BattleStarted = false;
    }

    public void SetBattle(Player player, NPCBase enemy)
    {
        BattleUIManager = new BattleUIManager(this,UIManager.Instance.Find<BattlePanel>());
        InputManager = new BattlePlayerInputManager(this);

        PlayerParty = player.BattleParty;
        EnemyParty = enemy.BattleParty;

        CurrentPlayerUnit = PlayerParty.Find((unit) => unit.IsFirst);
        if (CurrentPlayerUnit == null)
        {
            CurrentPlayerUnit = PlayerParty[0];
        }

        //TODO:���ܻ���������״̬���׷���λ����Ҫ�ж��Ƿ����������������״̬��Ĭ�ϻ���һ����ɫ��ս
        if (CurrentPlayerUnit.IsDead) {
            CurrentPlayerUnit = PlayerParty.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyParty.First();

        CurrentPlayerBattleUnit = new BattleUnit(CurrentPlayerUnit);
        CurrentEnemyBattleUnit = new BattleUnit(CurrentEnemyUnit);

        SkillPools = new Dictionary<PokeGirl, SkillCardPool>();

        //TODO:ս����ʼ
        CoroutineManager.Instance.CreateCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattleState = BattleState.BattleStart;
        BattleUIManager.InitBattle();

        //TODO:����UI�����볡����

        BattleState = BattleState.FirstRound;
        yield break;
    }

    //TODO:��ʼս��ʱ��ÿ���غϽ���ʱ���ᷢ��
    public IEnumerator RoundStart()
    {
        BattleState = BattleState.RoundStart;
        Round++;
        
        yield break;
    }

    public IEnumerator RoundEnd()
    {

        yield break;
    }

    public bool SendCards(BattleUnit unit,int cardNum)
    {
        //TODO:������ҵ�ǰ��λ��װ���ļ��ܷ����ܿ����������������еĿ���Ҫ��Ӧ���������
        if (!SkillPools.ContainsKey(unit.PokeGirl))
        {
            var skillPool = new SkillCardPool(unit.PokeGirl.EquipedSkills);
            SkillPools.Add(unit.PokeGirl, skillPool);
            for (int i = 0; i < cardNum; i++)
            {
                var skill = skillPool.GetCard();
                if (skill != null)
                {
                    unit.AddSkillCard(skill);
                }
                else
                {
                    return false;
                }
  
            }
        }
        else
        {
            for (int i = 0; i < cardNum; i++)
            {
                var card = SkillPools[unit.PokeGirl].GetCard();
                if (card != null) {
                    unit.AddSkillCard(card);
                }
                else {
                    return false;
                }
            }

        }

        RefreshBattleUI();
        return true;
    }

}
