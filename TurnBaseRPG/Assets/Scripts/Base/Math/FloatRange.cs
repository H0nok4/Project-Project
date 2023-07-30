using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatRange{
    public readonly float Left;
    public readonly float Right;

    public FloatRange(float left, float right) {
        this.Left = left;
        this.Right = right;
    }

    public float GetValue() {
        return Random.Range(Left, Right);
    }


}
