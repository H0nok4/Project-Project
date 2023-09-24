using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIComponent : MonoBehaviour
{
    protected bool _inited = false;

    public Image GetImageAtChildIndex(int index)
    {
        return transform.GetChild(index).GetComponent<Image>();
    }

    public TMP_Text GetTextAtChildIndex(int index)
    {
        return transform.GetChild(index).GetComponent<TMP_Text>();
    }

    public UIComponent GetUIComponentAtChildIndex(int index) {
        var uiComponent = transform.GetChild(index).GetComponent<UIComponent>();
        uiComponent.Init();
        return uiComponent;
    }

    public UIList GetUIListAtChildIndex(int index)
    {
        var uiList = transform.GetChild(index).GetComponent<UIList>();
        uiList.Init();
        return uiList;
    }

    public void Init()
    {
        if (_inited)
        {
            return;
        }

        InitInstance();
        _inited = true;
    }

    public abstract void InitInstance();
}
