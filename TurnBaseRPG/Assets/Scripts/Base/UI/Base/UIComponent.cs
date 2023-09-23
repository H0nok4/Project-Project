using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIComponent : MonoBehaviour
{

    private void Awake()
    {
        InitInstance();
    }

    public Image GetImageAtChildIndex(int index)
    {
        return transform.GetChild(index).GetComponent<Image>();
    }

    public TMP_Text GetTextAtChildIndex(int index)
    {
        return transform.GetChild(index).GetComponent<TMP_Text>();
    }

    public UIComponent GetUIComponentAtChildIndex(int index)
    {
        return transform.GetChild(index).GetComponent<UIComponent>();
    }

    public abstract void InitInstance();
}
