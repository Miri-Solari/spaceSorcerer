using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public El_Type Elem;

    public Unit Affected;
    public EffectType Type;
    public float Multi;
    public float time;
    public enum EffectType {Fire, Oxy, Aero, Geo, Water, Kryo, Stun}
    private double[] Resistances = new double[6];
    private float Speed;


    public void SetAffected(Unit affected)
    {
        Affected = affected;
    }
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Resistances[i] = Affected.Resistances[i];
        }
        Speed = Affected.Speed;
        print(Elem);
        switch (Type)
        {
            case EffectType.Fire:
                InvokeRepeating(nameof(Fire), 0f, 0.5f); // Add GiveGun
                break;

            case EffectType.Oxy:
                ResistDebuffAll(1.33f);
                break;
            case EffectType.Aero:
                Disarm();
                break;
            case EffectType.Geo:
                Slow(Multi);
                break;
            case EffectType.Water:
                Wet(Multi);
                break;
            case EffectType.Kryo:
                Cooled(Multi);
                break;
            case EffectType.Stun:
                Stun();
                break;
        }
    }


    void Update()
    {
        if (time <= 0)
        {
            for (int i = 0; i < 6; i++)
            {
                Affected.Resistances[i] = Resistances[i];
            }
            Affected.Speed = Speed;
            Affected.IsAffected = false;
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        if (time <=0) 
        {
            
            Destroy(gameObject);
        }
        time -= 0.02f;
        
        
        
    }

    void Fire()
    {
        //print($"ÿ åáàë âàøó ìàøó{Multi}");
        Affected.TakeDamege(Multi*0.5f, Elem);
    }


    void ResistDebuff(int num_el, float multi)
    {
        Affected.Resistances[num_el] /= multi;
    }

    void ResistDebuffAll(float multi)
    {
        for (int i = 0; i < 6; i++)
        {
            ResistDebuff(i, multi);
        }
    }


    void Disarm()
    {
        // ÍÀÄÎ ÐÅÀËÈÇÎÂÀÒÜ ÊÀÊ ÁÓÄÅÒ ÃÎÒÎÂ ÀÈØÍÈÊ
    }

    void Slow(float multi)
    {
        Affected.Speed -= Affected.Speed * multi;
    }


    void Stun()
    {
        // ÐÅÀËÈÇÎÂÀÒÜ ÏÎÑËÅ ÀÈØÍÈÊÀ
    }

    void Wet(float multi)
    {
        Slow(multi * 0.5f);
        ResistDebuff(5, 1.2f);
        ResistDebuff(2, 1.2f);
    }

    void Cooled(float multi)
    {
        Slow(multi * 2);
        ResistDebuff(0, 0.8f);
        ResistDebuff(4, 1.2f);
    }

    
}
