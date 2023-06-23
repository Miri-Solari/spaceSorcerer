using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Temp_Dmg_Multi;
    public Layer Temp_layer_Out;
    public Layer Temp_layer_Mid;
    public Layer Temp_layer_Inn;
    public LayerMask WhatIsSolid;

    public float Dmg_Multi { get; private set; }
    public Layer Layer_Out { get; private set; }
    public Layer Layer_Mid { get; private set; }
    public Layer Layer_Inn { get; private set; }

    void Start()
    {
        Dmg_Multi = Temp_Dmg_Multi;
        Layer_Out = Temp_layer_Out;
        Layer_Mid = Temp_layer_Mid;
        Layer_Inn = Temp_layer_Inn;
    }


}
