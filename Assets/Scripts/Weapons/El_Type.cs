using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class El_Type : MonoBehaviour
{
    public int Elem;
    public int Num_El { get; private set; }
    void Start()
    {
        Num_El = Elem;
    }

}
