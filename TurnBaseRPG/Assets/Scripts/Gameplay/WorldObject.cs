using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldObject : MonoBehaviour, IInteractive {
    public Transform TransformComponent;

    public Collider2D ColliderComponent;

    private void Start() {
        TransformComponent = GetComponent<Transform>();
        ColliderComponent = GetComponent<Collider2D>();
        
        InitObject();
    }

    public virtual void InitObject() {

    }

    public virtual void OnTrigger() {
        
    }

    public virtual void OnDestroy() {

    }

    public virtual void OnSpawn() {

    }
}
