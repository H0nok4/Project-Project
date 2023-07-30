

using System.Threading;
using UnityEngine;

public static class RealTime {
    public static float deltaTime;

    public static float realDeltaTime;

    public static int frameCount;

    private static float unpausedTime;

    private static float lastRealTime = 0f;

    public static float LastRealTime => lastRealTime;

    public static float UnpausedRealTime => unpausedTime;

    public static void Update() {
        frameCount = Time.frameCount;
        deltaTime = Time.deltaTime;
        float realtimeSinceStartup = Time.realtimeSinceStartup;
        realDeltaTime = realtimeSinceStartup - lastRealTime;
        lastRealTime = realtimeSinceStartup;
    }
}