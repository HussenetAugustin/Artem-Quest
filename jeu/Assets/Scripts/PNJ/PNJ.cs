using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PnjState
{
    idle,
    speaking
}

public class PNJ : MonoBehaviour
{
    public GameObject Notif;
    public Dialog dialog;
    private Animator anim;
    private bool playerInRange;
    private DialogManager dialogManager;
    private PnjState currentState;
    private GameObject player;

    private void Start()
    {
        currentState = PnjState.idle;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        dialogManager = GetComponent<DialogManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(currentState == PnjState.idle)
            {
                player.GetComponent<PlayerMovement>().currentState = PlayerState.speaking;
                dialogManager.StartDialog(dialog);
                Notif.SetActive(false);
                anim.SetBool("Speaking", true);
                currentState = PnjState.speaking;
            }
            else
            {
                dialogManager.ContinueDialog();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().currentState = PlayerState.interact;
            playerInRange = true;
            if (Notif != null)
            {
                Notif.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().currentState = PlayerState.walk;
            playerInRange = false;
            if (Notif != null)
            {
                Notif.SetActive(false);
            }
            currentState = PnjState.idle;
            anim.SetBool("Speaking", false);
        }
    }

}
