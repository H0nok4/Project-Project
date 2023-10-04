using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableEvents<T> where T : new() {
    void OnSpawned(IRecycler<T> poolRecycler);

    void OnRecycle();
}
