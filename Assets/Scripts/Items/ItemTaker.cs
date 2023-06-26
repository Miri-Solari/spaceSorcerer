using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public Inventory TargetInventory;
    public GameObject PrefabInventoryItem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            for (int i = 0; i < TargetInventory.Slots.Length; i++)
            {
                if (TargetInventory.IsFull[i] == false)
                {
                    TargetInventory.IsFull[i] = true;
                    Instantiate(PrefabInventoryItem, TargetInventory.Slots[i].transform);
                    
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
