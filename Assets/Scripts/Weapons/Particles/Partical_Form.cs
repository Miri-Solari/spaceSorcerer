using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partical_Form : MonoBehaviour
{
    public Form_type Type;

    public enum Form_type
    {
        Simple_Bullet, Ray, Rocket, Wave_In_Front, Wave_Around, Short_Wave_In_Front, Cone, Clot, Explozion_Clot, Mine, Fraction
    }
    void Start()
    {
        
    }

    void Create_Partical()
    {
        if( Type == Form_type.Simple_Bullet) // Простой одиночный выстрел
        {

        }
        else if( Type == Form_type.Ray) // Луч
        {

        }
        else if ( Type == Form_type.Rocket) // Ракета
        {

        }
        else if ( Type == Form_type.Wave_In_Front) // Волна перед персонажем
        {

        }
        else if (Type == Form_type.Wave_Around) // Волна вокруг персонажа
        {

        }
        else if (Type == Form_type.Short_Wave_In_Front) // Короткая волна перед
        {

        }
        else if (Type == Form_type.Cone) // Конус
        {

        }
        else if (Type == Form_type.Clot) // Сгусток
        {

        }
        else if (Type == Form_type.Explozion_Clot) // Взрывной Сгусток
        {

        }
        else if (Type == Form_type.Mine) // Мина
        {

        }
        else if (Type == Form_type.Fraction) // Дробь
        {

        }
    }

    
}
