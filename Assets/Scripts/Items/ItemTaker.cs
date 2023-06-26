using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public Inventory TargetInventory;
    public GameObject SlotButton;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            for (int i = 0; i < TargetInventory.Slots.Length; i++)
            {
                if (TargetInventory.IsFull[i] == false)
                {
                    TargetInventory.IsFull[i] = true;

                    Instantiate(SlotButton, TargetInventory.Slots[i].transform);
                    El_Type temp = TargetInventory.Slots[i].AddComponent<El_Type>();
                    temp = SlotButton.GetComponent<El_Type>();
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
