using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    private int speed = 1;
    public GameObject target;
    public PlayerInventory inventory;
    public InventoryItem item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inventory.inventory.Contains(item))
        {
            StartCoroutine(moveToward());
        }
    }

    IEnumerator moveToward()
    {
        while (transform.position.y < target.transform.position.y)
        {
            transform.position += new Vector3(0, Time.deltaTime*speed, 0);
            yield return null;
        }
    }


}
