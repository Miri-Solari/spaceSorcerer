using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsInventory
{
    [SerializeField] private Weapon[] weapons = new Weapon[2];
    private int _index=2;
    public Weapon CurrentWeapon => weapons[_index];
    
    public void TakeWeapon( Weapon w)
    {
        
    }
}
