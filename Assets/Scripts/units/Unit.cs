using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public double ResPyro, ResWater, ResKryo, ResOxy, ResGeo, ResAero;
    public int HP;
    public double SpeedX, SpeedY;
    private double[] Resistances = new double[6];
    private double MinRes;


    void Start()
    {
        gameObject.tag = "Unit";
        Resistances[0] = ResPyro/100;
        Resistances[1] = ResWater/100;
        Resistances[2] = ResKryo / 100;
        Resistances[3] = ResOxy / 100;
        Resistances[4] = ResGeo / 100;
        Resistances[5] = ResAero / 100;
        MinRes = Resistances.Min();
    }

    void Update()
    {
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamege(double dmg, El_Type Elem)
    {
        HP -= Convert.ToInt32(dmg * (1 - Resistances[Elem.Num_El]));
    }
}
