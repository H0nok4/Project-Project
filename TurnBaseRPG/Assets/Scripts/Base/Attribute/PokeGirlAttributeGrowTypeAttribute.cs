using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeGirlAttributeGrowTypeAttribute : System.Attribute
{
    public PokeGirlAttributeType Type;

    public PokeGirlAttributeGrowTypeAttribute(PokeGirlAttributeType type)
    {
        Type = type;
    }
}
