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

    [Header("�б�ʹ�õ������壨��ʱ��")]
    public GameObject ListChildrenInstance;

    public int ChildCount
    {
        get => ChildList.Count;
        set
        {
            if (ChildCount > value)
            {
                int num = ChildCount - value;
                for (int i = 0; i < num; i++)
                {
                    RemoveChildAt(ChildCount - 1);
                }
            }
            else
            {
                int num = value - ChildCount;
                for (int i = 0; i < num; i++)
                {
                    AddChild();
                }
            }
        }
    }

    public void AddChild(UIComponent child)
    {
        ChildList.Add(child);
        //TODO:��Ҫ�ӵ�Context������
        child.transform.SetParent(_contentGameObject.transform);
        child.transform.localScale = Vector3.one;
    }

    public void AddChild()
    {
        if (ListChildrenInstance == null)
        {
            return;
        }

        var component = GameObject.Instantiate(ListChildrenInstance).GetComponent<UIComponent>();
        AddChild(component);
    }

    public void AddChildAt(UIComponent child, int index)
    {
        ChildList.Insert(index, child);
    }

    public void AddChildAt(int index)
    {
        if (ListChildrenInstance == null)
        {
            return;
        }
        var component = GameObject.Instantiate(ListChildrenInstance).GetComponent<UIComponent>();
        ChildList.Insert(index, component);
        component.transform.SetParent(_contentGameObject.transform);
    }

    public void RemoveChild(UIComponent child)
    {
        var removed = ChildList.Remove(child);
        child.transform.SetParent(null);
        //TODO:��ҪͶ�뵽������У�����ֱ������,������ֱ������
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

        //TODO:���һ�����е�Child
        var childCount = _contentGameObject.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            var child = _contentGameObject.transform.GetChild(i).gameObject;
            child.transform.SetParent(null);
            Destroy(child);
        }

    }
}