using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ICharacterBase
{
    public string Name { get; set; }
    public List<BattleUnit> BattleUnits { get; set; } = new List<BattleUnit>();
    public void OnDefeated()
    {
        //TODO:ս���˽���ս������,�����Ǵ���ս���¼����¼���������Իص����һ��ע��İ�ȫ��
    }

    public void OnVictory()
    {
        //TODO:ʤ���˽���ʤ������
    }

    public void OnBattleStart()
    {
        //TODO:������ʲô���߻����¼�����ս����ʼʱ����
    }

    public void OnBattleEnd()
    {
        //TODO:ͬ��������ʲô���߻����¼�����ս������ʱ����
    }
}
