using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGameObject : MonoBehaviour
{
    public int ID;

    public NPCBase NPCBase { get; set; }

    private void Start()
    {
        Init(ID);
    }

    public void Init(int id)
    {
        NPCBase = new NPCBase(id);
    }
}
