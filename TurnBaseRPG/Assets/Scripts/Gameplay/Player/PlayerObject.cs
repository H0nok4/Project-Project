using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public void Update() {
        //TODO:后面需要一个专门的地方处理输入
        HandleMove();
    }

    public void HandleMove() {
        if (Input.GetKeyDown(KeyCode.W)) {
            //TODO:向上移动

        }
        else if (Input.GetKeyDown(KeyCode.D)) {

        }
        else if (Input.GetKeyDown(KeyCode.S)) {

        }
        else if (Input.GetKeyDown(KeyCode.A)) {

        }
    }

    public void HandleInteract() {
        if (Input.GetKeyDown(KeyCode.E)) {
            
        }
    }
}
