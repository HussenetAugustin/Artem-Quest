using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatch : MonoBehaviour
{
    public InventoryManager thisManager;
    public InventoryItem thisItem;
    public GameObject InventoryFull;
    private bool canCatch = false;
    private bool canCatch2 = false;

    private void Update()
    {
        if (canCatch && !canCatch2)
        {
            if (Input.GetButtonDown("Interact"))
            {
                thisManager.addItem(thisItem);
                Destroy(this.gameObject);
            }
        }
        else if (canCatch)
        {
            if (Input.GetButtonDown("Interact"))
            {
                thisManager.InventoryFullAppear();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter heart place");
        canCatch = true;
        if (thisManager.playerInventory.inventory.Count == thisManager.playerInventory.inventory_size)
        {
            if (thisManager.playerInventory.inventory.Contains(thisItem))
            {
                canCatch2 = false;
            }
            else
            {
                canCatch2 = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Leave heart place");
        canCatch = false;
    }


}
