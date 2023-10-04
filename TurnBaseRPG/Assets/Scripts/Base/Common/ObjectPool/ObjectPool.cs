using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IRecycler<T> where T : new() {
    public enum MaxCapacityBehaviour {
        ReturnNull,
        RecycleOldest,
        Expand
    }

    protected Queue<T> m_CachedInstances;

    protected List<T> m_Spawned;

    protected MaxCapacityBehaviour m_MaxCapacityBehaviour;

    public bool IsInitialized => m_CachedInstances != null;

    private void CreatePool(int numInstances) {
        m_CachedInstances = new Queue<T>(numInstances);
        m_Spawned = new List<T>(numInstances);
        if (!typeof(T).IsAssignableFrom(typeof(MonoBehaviour))) {
            for (int i = 0; i < numInstances; i++) {
                m_CachedInstances.Enqueue(CreateObject());
            }
        }
    }

    public void Initialize(int capacity, MaxCapacityBehaviour maxCapacityBehaviour) {
        CreatePool(capacity);
        m_MaxCapacityBehaviour = maxCapacityBehaviour;
    }

    protected virtual T CreateObject() {
        return new T();
    }

    protected virtual void OnSpawn(T instance) {
        if (instance is IPoolableEvents<T>) {
            ((IPoolableEvents<T>)(object)instance).OnSpawned(this);
        }
    }

    protected virtual void OnRecycle(T instance) {
        if (instance is IPoolableEvents<T>) {
            ((IPoolableEvents<T>)(object)instance).OnRecycle();
        }
    }

    public virtual T Spawn() {
        if (m_CachedInstances == null) {
            Debug.LogError("Initialize() should be called before spawning.");
        }
        while (m_CachedInstances.Count > 0) {
            T pooled = m_CachedInstances.Dequeue();
            if (pooled != null && !pooled.ToString().Equals("null", StringComparison.OrdinalIgnoreCase)) {
                m_Spawned.Add(pooled);
                OnSpawn(pooled);
                return pooled;
            }
        }
        if (m_CachedInstances.Count <= 0) {
            switch (m_MaxCapacityBehaviour) {
                case MaxCapacityBehaviour.ReturnNull:
                    return default(T);
                case MaxCapacityBehaviour.RecycleOldest: {
                        T oldest = m_Spawned[0];
                        m_Spawned.RemoveAt(0);
                        OnRecycle(oldest);
                        m_Spawned.Add(oldest);
                        OnSpawn(oldest);
                        return oldest;
                    }
                case MaxCapacityBehaviour.Expand: {
                    Debug.LogWarning($"池子空间不够，容量为：{m_Spawned.Capacity}，需要扩容");
                        T obj = CreateObject();
                        m_Spawned.Add(obj);
                        OnSpawn(obj);
                        return obj;
                    }
                default:
                    return default(T);
            }
        }
        return default(T);
    }

    public void Recycle(T instance) {
        if (m_Spawned.Contains(instance)) {
            m_Spawned.Remove(instance);
            m_CachedInstances.Enqueue(instance);
            OnRecycle(instance);
        }
        else {
            Debug.LogWarning("不是这个池子生成的");
        }
    }
}
