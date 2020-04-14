using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [Header("UI stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText; // Nombre d'items dans le stack
    [SerializeField] private Image itemImage; // Image de l'objet à afficher dans l'inventaire

    [Header("Variable from the item")]
    public InventoryItem thisItem; // L'item contenu dans le slot
    public InventoryManager thisManager; // L'inventory manager


    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = ""+thisItem.numberHeld;
        }
    }


    public void setDescriptionAndBtn()
    {
        thisManager.setDescription(thisItem);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
