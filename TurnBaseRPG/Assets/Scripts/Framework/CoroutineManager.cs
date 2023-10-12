using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoSingleton<CoroutineManager>
{
    // 开启协程
    public Coroutine StartCoroutine(IEnumerator routine) {
        return StartCoroutine(routine);
    }

    // 停止协程
    public void StopCoroutine(Coroutine routine) {
        StopCoroutine(routine);
    }
}
