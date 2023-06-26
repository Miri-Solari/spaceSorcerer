using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_item : MonoBehaviour
{
    public Inventory TargetInventory;
    public int i;


    public void DropItem()
    {
        var trans = TargetInventory.Slots[i].GetComponentInChildren<Spawn>();
        trans.SpawnItem(TargetInventory, i);
        Destroy(trans.gameObject);
        
    }
}
