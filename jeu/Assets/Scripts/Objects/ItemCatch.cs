using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatch : MonoBehaviour
{
    public InventoryManager thisManager;
    public InventoryItem thisItem;
    private bool canCatch = false;

    private void Update()
    {
        if (canCatch)
        {
            if (Input.GetButtonDown("Interact"))
            {
                thisManager.addItem(thisItem);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter heart place");
        canCatch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Leave heart place");
        canCatch = false;
    }


}
