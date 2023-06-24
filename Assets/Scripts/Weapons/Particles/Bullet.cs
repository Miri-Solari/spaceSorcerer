using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Layer Layer_Out;
    public Layer Layer_Mid;
    public Layer Layer_Inn;
    public LayerMask WhatIsSolid;


    public (float, El_Type) GiveOutLayerStats()
    {
        if (Layer_Out != null)
        {
            print(Layer_Out.Elem);
            return (Layer_Out.Dmg, Layer_Out.Elem);
        }
        else return (0, null);
    }

    public (float, El_Type) GiveMidLayerStats()
    {
        if(Layer_Mid != null) 
            return (Layer_Mid.Dmg, Layer_Mid.Elem);
        else return (0, null);
    }

    public (float, El_Type) GiveInnLayerStats()
    {
        if (Layer_Inn != null)
            return (Layer_Inn.Dmg, Layer_Inn.Elem);
        else return (0, null);
    }


    void Start()
    {

    }

    
}
