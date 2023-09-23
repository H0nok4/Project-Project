using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
    private bool _inited = false;

    protected bool _disposed = false;

    public bool IsShow
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    private void Show()
    {
        if (!_inited)
        {
            Init();
        }

        gameObject.SetActive(true);
        OnShow();
    }

    private void Hide()
    {
        OnHide();

        gameObject.SetActive(false);
    }

    private void Init()
    {
        OnInit();

        _inited = true;
    }

    private void Dispose()
    {
        OnDispose();
        Destroy(gameObject);

        _disposed = true;
    }

    public virtual void OnInit()
    {

    }

    public virtual void OnDispose()
    {

    }

    public virtual void OnShow()
    {

    }

    public virtual void OnHide()
    {
    }

    public Image GetImageAtChildIndex(int index) {
        return transform.GetChild(index).GetComponent<Image>();
    }

    public TMP_Text GetTextAtChildIndex(int index) {
        return transform.GetChild(index).GetComponent<TMP_Text>();
    }

    public UIComponent GetUIComponentAtChildIndex(int index) {
        return transform.GetChild(index).GetComponent<UIComponent>();
    }

    public abstract void InitInstance();
}
