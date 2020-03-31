using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory information")]
    public PlayerInventory playerInventory; //Inventaire du joueur
    [SerializeField] private GameObject inventoryFull; // Message à afficher quand l'inventaire est plein
    [SerializeField] private GameObject player; // Joueur
    [SerializeField] private GameObject inventoryCanvas; // Le canvas à activer quand on ouvre l'inventaire
    [SerializeField] private GameObject Canvas; //
    [SerializeField] private GameObject blankInventorySlot; // Prefab Slot à remplir
    [SerializeField] private GameObject inventoryPanel; // Paneau contenant les Slots d'inventaire
    [SerializeField] private TextMeshProUGUI descriptionText; // Texte ou afficher la description de l'objet
    [SerializeField] private GameObject useButton; // Bouton pour utiliser (ici jeter l'objet)
    [SerializeField] private InventoryItem[] setUp; //Liste des tous les items du jeu pour mettre a jour l'inventaire au Start

    private InventoryItem ItemToUse;
    private bool inventoryActive;



    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    public void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i<playerInventory.inventory.Count; i++)
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);

                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.inventory[i], this);
                }
            }
        }
    }

    void ReloadInventory()
    {
        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        MakeInventorySlots();
    }

    public void setDescription(InventoryItem item)
    {
        descriptionText.text = item.itemDescription;
        if (item.usable)
        {
            useButton.SetActive(true);
            ItemToUse = item;
        }
        else useButton.SetActive(false);
    }

    public void addItem(InventoryItem item)
    {
        if (item.numberHeld > 0 && !item.unique)
        {
            item.numberHeld++;
            ReloadInventory();
        }
        else if (playerInventory.inventory_size > playerInventory.inventory.Count)
        {
            item.numberHeld++;
            playerInventory.inventory.Add(item);
            ReloadInventory();
        }
    }

    public void removeItem()
    {
        GameObject gameObject = Instantiate(ItemToUse.itemPrefab, player.transform.position, Quaternion.identity);
        gameObject.GetComponent<ItemCatch>().thisManager = Canvas.GetComponent<InventoryManager>();
        //GameObject gameObj = Instantiate(ItemToUse, transform.position, Quaternion.identity);
        if (ItemToUse.numberHeld > 1)
        {
            ItemToUse.numberHeld--;
            ReloadInventory();
        }
        else
        {
            ItemToUse.numberHeld--;
            playerInventory.inventory.Remove(ItemToUse);
            SetTextAndButton("", false);
            ReloadInventory();
        }
    }

    public void resetInventory()
    {
        playerInventory.inventory.Clear();
        for (int i = 0; i < setUp.Length; i++)
        {
            if (setUp[i].numberHeld > 0)
            {
                playerInventory.inventory.Add(setUp[i]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resetInventory();
        inventoryActive = false;
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!inventoryActive)
            {
                inventoryCanvas.SetActive(true);
                inventoryActive = true;
            }
            else
            {
                inventoryCanvas.SetActive(false);
                descriptionText.text = "";
                useButton.SetActive(false);
                inventoryActive = false;
            }
        }
    }



   public  void InventoryFullAppear()
    {
        inventoryFull.SetActive(true);
    }

    public void InventoryFullDisappear()
    {
        inventoryFull.SetActive(false);
    }
}
