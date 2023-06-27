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
        if (trans != null)
        {
            trans.SpawnItem(TargetInventory, i);
            Destroy(trans.gameObject);
            return;
        }
    }
}
