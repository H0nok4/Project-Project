using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoSingleton<CoroutineManager>
{
    // ����Э��
    public Coroutine StartCoroutine(IEnumerator routine) {
        return StartCoroutine(routine);
    }

    // ֹͣЭ��
    public void StopCoroutine(Coroutine routine) {
        StopCoroutine(routine);
    }
}
