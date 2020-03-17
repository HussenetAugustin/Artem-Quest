using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeakingPNJ : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private bool playerInRange;
    public Signal contextClueOnSignal;
    public Signal contextClueOffSignal;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                contextClueOffSignal.Raise();
                dialogBox.SetActive(false);
            }
            else
            {
                contextClueOnSignal.Raise();
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().currentState = PlayerState.interact;
            playerInRange = true;
            //contextClueOnSignal.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().currentState = PlayerState.walk;
            playerInRange = false;
            dialogBox.SetActive(false);
            //contextClueOffSignal.Raise();
        }
    }

}
