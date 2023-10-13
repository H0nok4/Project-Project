using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoSingleton<CoroutineManager>
{
    // 开启协程
    public Coroutine CreateCoroutine(IEnumerator routine) {
        return StartCoroutine(routine);
    }

    // 停止协程
    public void Stop(Coroutine routine) {
        StopCoroutine(routine);
    }
}
