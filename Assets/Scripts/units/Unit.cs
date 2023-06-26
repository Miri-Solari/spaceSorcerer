using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int HP;
    public float Speed;
    public Gun Weapon;
    public double[] Resistances = new double[6];
    public bool IsAffected = false;
    public double MinRes { get; private set; }



    void Start()
    {
        gameObject.tag = "Unit";
        MinRes = Resistances.Min();
    }

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamege(double dmg, El_Type Elem)
    {

        if (Elem != null)
        {
            HP -= Convert.ToInt32(dmg * (1 - Resistances[Elem.Num_El] / 100));
            print($"Нанесён урон: {Convert.ToInt32(dmg * (1 - Resistances[Elem.Num_El] / 100))}");
        }
    }

    public Gun GiveGun()
    {
        return Weapon;
    }

}
