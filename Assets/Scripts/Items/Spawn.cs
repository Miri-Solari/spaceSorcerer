using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ItemToSpawn;
    // Start is called before the first frame update
    public void SpawnItem(Inventory targetInventory, int i)
    {

        Vector2 position = new Vector2(targetInventory.GetComponent<Player>().transform.position.x - 2, targetInventory.GetComponent<Player>().transform.position.y - 2);
        ItemTaker temp = Instantiate(ItemToSpawn, position, Quaternion.identity).GetComponent<ItemTaker>();
        temp.TargetInventory = targetInventory;
        targetInventory.IsFull[i] = false;
    }
}
