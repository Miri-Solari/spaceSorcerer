using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public El_Type Temp_El;
    public float Temp_Dmg;
    public Effect Effect;

    public El_Type Elem {  get; private set; }
    public float Dmg { get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        Elem = Temp_El;
        Dmg = Temp_Dmg;
    }

    void GiveEffect(Unit Uni)
    {
        
    }

}
