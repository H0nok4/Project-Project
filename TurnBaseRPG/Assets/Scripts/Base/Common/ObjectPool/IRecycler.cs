using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycler<T> {
    void Recycle(T instance);
}
