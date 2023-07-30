using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConfigType;

[SerializeField]
public class PokeGirl 
{
    //角色类中，需要基础属性值，计算升级后的属性值，个体值，种族值，类似Pokemon那样的角色类
    public int Id;

    public string Name;

    public int Level;

    public int Exp;

    /// <summary>
    /// 基础属性和种族值相关
    /// </summary>
    public PokeGirlAttributeBase AttributeBase;


}
