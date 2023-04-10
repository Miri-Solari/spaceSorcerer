using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour,IInteractable
{
    [SerializeField] private string _desc;
    public string Description 
    {
        get { return _desc; }
        set { _desc = value; }
    }

    public void Interact(GameObject obj)
    {

    }
    [SerializeField] string _name;
    [SerializeField] float _fireRate;

    public string Name => _name;
    public float FireRate => _fireRate;

}
