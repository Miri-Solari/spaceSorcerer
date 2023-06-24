using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Layer Temp_layer_Out;
    public Layer Temp_layer_Mid;
    public Layer Temp_layer_Inn;
    public LayerMask WhatIsSolid;

    public Layer Layer_Out { get; private set; }
    public Layer Layer_Mid { get; private set; }
    public Layer Layer_Inn { get; private set; }


    public (float, El_Type) GiveOutLayerStats()
    {
        return (Layer_Out.Dmg, Layer_Out.Elem);
    }

    public (float, El_Type) GiveMidLayerStats()
    {
        return (Layer_Mid.Dmg, Layer_Mid.Elem);
    }

    public (float, El_Type) GiveInnLayerStats()
    {
        return (Layer_Inn.Dmg, Layer_Inn.Elem);
    }


    void Start()
    {

        Layer_Out = Temp_layer_Out;
        Layer_Mid = Temp_layer_Mid;
        Layer_Inn = Temp_layer_Inn;
    }

    
}
