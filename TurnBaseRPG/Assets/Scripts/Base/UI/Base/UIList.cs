using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIList : UIComponent
{
    public List<UIComponent> ChildList = new List<UIComponent>();
    private GameObject _contentGameObject;
    private GridLayoutGroup _contentLayoutGroup;
    public void AddChild(UIComponent child)
    {
        ChildList.Add(child);
        //TODO:需要加到Context物体下
        child.transform.SetParent(_contentGameObject.transform);
    }

    public void RemoveChild(UIComponent child)
    {
        var removed = ChildList.Remove(child);
        child.transform.SetParent(null);
        //TODO:需要投入到对象池中，或者直接销毁,这里先直接销毁
        if (removed)
        {
            Destroy(child.gameObject);
        }
    }

    public void RemoveChildAt(int index)
    {
        var child = ChildList[index];
        RemoveChild(child);
    }

    public void RemoveAllChild()
    {
        foreach (var uiComponent in ChildList)
        {
            RemoveChild(uiComponent);
        }
    }

    public override void InitInstance()
    {
        _contentGameObject = transform.GetChild(0).GetChild(0).gameObject;
        _contentLayoutGroup = _contentGameObject.GetComponent<GridLayoutGroup>();

        //TODO:清空一下现有的Child
        var childCount = _contentGameObject.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            var child = _contentGameObject.transform.GetChild(i).gameObject;
            child.transform.SetParent(null);
            Destroy(child);
        }

    }
}
