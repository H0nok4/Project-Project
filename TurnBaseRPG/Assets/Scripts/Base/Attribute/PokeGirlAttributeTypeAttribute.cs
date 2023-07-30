using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeGirlAttributeTypeAttribute : Attribute
{
    public PokeGirlAttributeType Type;

    public PokeGirlAttributeTypeAttribute(PokeGirlAttributeType type)
    {
        Type = type;
    }
}
