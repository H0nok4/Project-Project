using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : UIComponent
{
    public Image m_Background;
    public Image m_valueImage;
    public override void InitInstance()
    {
        m_Background = GetImageAtChildIndex(0);
        m_valueImage = GetImageAtChildIndex(1);
    }
}
