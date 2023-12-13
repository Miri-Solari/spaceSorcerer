using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    public TypeElem Elem;
    public float Dmg;

    public Layer(TypeElem elem, float dmg)
    {
        Elem = elem;
        Dmg = dmg;
    }

}
