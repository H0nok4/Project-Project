using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoSingleton<CoroutineManager>
{
    // ����Э��
    public Coroutine CreateCoroutine(IEnumerator routine) {
        return StartCoroutine(routine);
    }

    // ֹͣЭ��
    public void Stop(Coroutine routine) {
        StopCoroutine(routine);
    }
}
