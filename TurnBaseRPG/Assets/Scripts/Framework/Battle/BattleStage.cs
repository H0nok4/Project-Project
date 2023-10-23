using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Base;
using Assets.Scripts.Battle;
using Battle;
using ConfigType;
using UI;
using UI.Battle;
using UnityEngine;
using UnityEngine.Playables;

public enum BattleState
{
    BattleStart,
    //TODO:以后应该会有播剧情阶段，可能会随时插入战斗
    FirstRound,
    CalculateSpeed,
    RoundStart,
//    DrawCard,//双方抽卡环节
    PlayerTurn,
    PerformPlayerAction,
    PlayerTurnEnd,
    EnemyTurn,
    PerformEnemyAction,
    EnemyTurnEnd,
    RoundEnd,
    PerformRoundEnd,
    PlayerDeadSwitch,
    EnemyDeadSwitch,
    PlayerWin,
    PlayerLose,
}

public class BattleStage : Singleton<BattleStage>,IStageModel
{
    //TODO:一场战斗一般由俩名玩家，俩个队伍组成
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

    public BattleUnitGO CurrentPlayerUnitGO;
    public BattleUnitGO CurrentEnemyUnitGO;

    public Dictionary<PokeGirl, SkillCardPool> SkillPools;

    public PlayableDirector TimeLineDirector;

    public BattleState BattleState;

    public int Round;

    public bool LeftEnd;
    public bool RightEnd;

    public int PlayerUnitSkillPoint
    {
        get => CurrentPlayerBattleUnit.SkillPoint;
        set
        {
            CurrentPlayerBattleUnit.SkillPoint = value;
            BattleUIManager.SetPlayerSkillPoint(CurrentPlayerBattleUnit);
        }
    }

    public int EnemyUnitSkillPoint
    {
        get => CurrentEnemyBattleUnit.SkillPoint;
        set
        {
            CurrentEnemyBattleUnit.SkillPoint = value;
            BattleUIManager.SetEnemySkillPoint(CurrentEnemyBattleUnit);
        }
    }

    public int PlayerUnitHP
    {
        get => CurrentPlayerBattleUnit.CurrentHP;
        set
        {
            CurrentPlayerBattleUnit.CurrentHP = value;
            BattleUIManager.SetPlayerHP(CurrentPlayerBattleUnit);
        }
    }

    public int EnemyUnitHP
    {
        get => CurrentEnemyBattleUnit.CurrentHP;
        set
        {
            CurrentEnemyBattleUnit.CurrentHP = value;
            BattleUIManager.SetEnemyHP(CurrentEnemyBattleUnit);
        }
    }

    public bool BattleStarted
    {
        get => _battleStarted;
        set
        {
            _battleStarted = value;

            if (_battleStarted)
            {
                Debug.Log("开启战斗！");
            }
            else
            {
                Debug.Log("结束战斗！");
            }
        }
    }

    public SkillTimelineData SkillTimelineData { get; set; }


    public void OnEnter()
    {
        BattleStarted = true;
        EventManager.Instance.AddListener<float,Transform>(EventDef.PopupDamageText, PopupDamageText);
    }


    private void PopupDamageText(float value,Transform trans)
    {
        var go = GameObject.Instantiate(DataManager.Instance.GetUIPrefabByName("DamageText"), Vector3.zero,Quaternion.identity);
        DamageText damageText = go.GetComponent<DamageText>();
        damageText.SetDamage((int)value);
        go.transform.SetParent(trans);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
    }

    public void Update()
    {
        if (!_battleStarted)
        {
            //TODO:战斗循环，通过当前的状态
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
            //TODO:计算双方的速度，决定第一回合谁先动手
            CalculateSpeed();
        }else if (BattleState == BattleState.PlayerTurn)
        {
            //TODO:等待玩家输入指令
            CheckPlayerInput();
        }else if (BattleState == BattleState.PerformPlayerAction)
        {
            //TODO:根据玩家选择的行动，例如使用卡牌，切换单位，使用道具等，播放表现
        }
        else if (BattleState == BattleState.PlayerTurnEnd) {
            //玩家回合结束
            CheckPlayerTurnEnd();
        }
        else if (BattleState == BattleState.EnemyTurn)
        {
            //TODO:AI行动
            RunAITurn();
        }else if (BattleState == BattleState.PerformEnemyAction)
        {
            //TODO:根据AI选择的行动，例如使用卡牌，切换单位，使用道具等，播放表现
        }
        else if (BattleState == BattleState.EnemyTurnEnd)
        {
            CheckEnemyTurnEnd();
        }
        else if (BattleState == BattleState.RoundEnd)
        {
            //TODO:可能有每回合结算伤害的BUFF，然后就是BUFF计时减少1回合
            RoundEnd();
        }


    }

    private IEnumerator OnRoundEnd()
    {
        BattleState = BattleState.RoundStart;
        yield break;
    }

    private bool CheckHasDeadUnit()
    {
        //每次行动完都需要判断俩边的存活情况，可能被打死了或者被Debuff把自己烫死了之类的
        if (CurrentPlayerBattleUnit.IsDead)
        {
            if (!PlayerParty.Exists((unit)=>! unit.IsDead))
            {
                //TODO:玩家所有单位阵亡，结束战斗
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
            Debug.Log("俩方都结束行动，进入回合结算");
            BattleState = BattleState.RoundEnd;
            return;
        }

        if (LeftEnd) {
            Debug.Log("玩家已经结束行动，再次进入敌人行动");
            BattleState = global::BattleState.EnemyTurn;
            return;
        }

        if (!CheckHasDeadUnit())
        {
            Debug.Log("没有死亡的角色，进入玩家回合");
            BattleState = BattleState.PlayerTurn;
            return;
        }

    }

    private void CheckPlayerTurnEnd()
    {
        if (RightEnd && LeftEnd)
        {
            Debug.Log("俩方都结束行动，进入回合结算");
            BattleState = BattleState.RoundEnd;
            return;
        }

        if (RightEnd)
        {
            Debug.Log("敌人已经结束行动，再次进入玩家行动");
            BattleState = global::BattleState.PlayerTurn;
            return;
        }

        if (!CheckHasDeadUnit()) {
            Debug.Log("没有死亡的角色，进入敌人回合");
            BattleState = BattleState.EnemyTurn;
            return;
        }
     
    }

    private void RunAITurn()
    {
        if (RightEnd)
        {
            //已经宣告回合结束了，不再进入敌人回合
            BattleState = BattleState.EnemyTurnEnd;
            return;
        }
        
        //TODO:测试用，AI无脑结束回合
        Debug.Log("AI结束回合");
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
            //TODO:演出对应的技能
            if (context.SkillCard.Cost > PlayerUnitSkillPoint)
            {
                //TODO:技能点不足，需要提示
                Debug.LogError("技能点不足，无法使用这个技能卡");
                return;
            }
            OnPlayerSelectSkill(context.SkillCard);
        }else if (context.Type == PlayerInputContext.InputType.SelectEndTurn)
        {
            //回合结束了
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
        //TODO:扣除技能点
        PlayerUnitSkillPoint -= skillCard.Cost;

        //TODO:播放表现
        Debug.Log($"玩家选择了技能，技能名称为：{skillCard.Define.SkillName}");
        Debug.Log("开始播放技能表现——");
        //TODO:计算伤害
        var timelineData = BattleDetailGenerator.GenerateSkillDetail(skillCard, CurrentPlayerBattleUnit, CurrentEnemyBattleUnit);
        SkillTimelineData = timelineData;
        yield return BattlePerformenceManager.Perform(skillCard.TimelineAssets, timelineData, CurrentPlayerBattleUnit, CurrentEnemyBattleUnit);
        Debug.Log("技能表现播放结束");

        BattleState = BattleState.PlayerTurnEnd;
    }


    private void StartNewRound(bool firstRound = false)
    {
        
        if (firstRound)
        {
            Round = 1;
            Debug.Log("开启第一个回合");
            //TODO:第一回合，抽卡要抽3张
            SendCards(CurrentPlayerBattleUnit, 3);
            SendCards(CurrentEnemyBattleUnit, 3);
        }
        else
        {
            Round++;
            Debug.Log($"开启新回合，当前回合数：{Round}");
            //TODO:其他回合，抽卡只用抽1张
            SendCards(CurrentPlayerBattleUnit, 1);
            SendCards(CurrentEnemyBattleUnit, 1);
        }

        BattleUIManager.OnBattleRoundStart();

        //TODO:还要恢复技能点
        PlayerUnitSkillPoint = CurrentPlayerBattleUnit.MaxSkillPoint;
        EnemyUnitSkillPoint = CurrentEnemyBattleUnit.MaxSkillPoint;

        BattleState = BattleState.CalculateSpeed;

    }

    private void CalculateSpeed()
    {
        //TODO:临时用基础速度代替下
        if (CurrentPlayerBattleUnit.Speed >= CurrentEnemyBattleUnit.Speed)
        {
            Debug.Log("计算速度后，玩家先手");
            BattleState = BattleState.PlayerTurn;
        }
        else
        {
            Debug.Log("计算速度后，敌人先手");
            BattleState = BattleState.EnemyTurn;
        }


    }

    public void LateUpdate()
    {
        //TODO:刷新UI等

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
        EventManager.Instance.RemoveListener<float,Transform>(EventDef.PopupDamageText,PopupDamageText);
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

        //TODO:可能还会有死亡状态的首发单位，需要判断是否死亡，如果死亡的状态下默认换第一个角色出战
        if (CurrentPlayerUnit.IsDead) {
            CurrentPlayerUnit = PlayerParty.Find((unit) => !unit.IsDead);
        }
        CurrentEnemyUnit = EnemyParty.First();

        CurrentPlayerBattleUnit = new BattleUnit(CurrentPlayerUnit);
        CurrentEnemyBattleUnit = new BattleUnit(CurrentEnemyUnit);

        CurrentPlayerUnitGO.Unit = CurrentPlayerBattleUnit;
        CurrentEnemyUnitGO.Unit = CurrentEnemyBattleUnit;
        CurrentPlayerBattleUnit.GO = CurrentPlayerUnitGO;
        CurrentEnemyBattleUnit.GO = CurrentEnemyUnitGO;

        SkillPools = new Dictionary<PokeGirl, SkillCardPool>();

        //TODO:战斗开始
        CoroutineManager.Instance.CreateCoroutine(BattleStart());
    }

    public IEnumerator BattleStart()
    {
        BattleState = BattleState.BattleStart;
        BattleUIManager.InitBattle();

        //TODO:设置UI播放入场表现

        BattleState = BattleState.FirstRound;
        yield break;
    }

    //TODO:开始战斗时和每个回合结束时都会发卡
    public IEnumerator RoundStart()
    {
        BattleState = BattleState.RoundStart;
        Round++;
        
        yield break;
    }

    public void RoundEnd()
    {
        Debug.Log("回合结束");
        //TODO:
        LeftEnd = false;
        RightEnd = false;

        //TODO:
        CoroutineManager.Instance.CreateCoroutine(OnRoundEnd());

        BattleUIManager.OnBattleRoundEnd();
    }

    public bool SendCards(BattleUnit unit,int cardNum)
    {
        //TODO:根据玩家当前单位所装备的技能发技能卡，并且数量与手中的卡需要对应，比如带了
        if (!SkillPools.ContainsKey(unit.PokeGirl))
        {
            var skillPool = new SkillCardPool(unit.EquipedSkills);
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
