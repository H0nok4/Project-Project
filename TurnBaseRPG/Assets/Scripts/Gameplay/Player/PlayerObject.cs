using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : WorldObject {
    private Player _player;
    public override void InitObject() {
        //TODO:需要获得玩家的实例
    }

    public void Update() {
        //TODO:后面需要一个专门的地方处理输入

    }

    public void FixedUpdate() {
        HandleMove();
    }

    public void HandleMove() {
        int moveSpeed = 5;
        Vector3 moveVec = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            //TODO:向上移动
            moveVec += Vector3.up;
        }

        if (Input.GetKey(KeyCode.D)) {
            moveVec += Vector3.right;
        }

        if (Input.GetKey(KeyCode.S)) {
            moveVec += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A)) {
            moveVec += Vector3.left;
        }

        transform.Translate(moveVec * moveSpeed * Time.fixedDeltaTime);
    }

    public void HandleInteract() {
        if (Input.GetKeyDown(KeyCode.E)) {
            
        }
    }
}
