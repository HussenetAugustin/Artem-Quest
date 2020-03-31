using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLaunch : MonoBehaviour
{
    public GameObject dialog_man;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("Interact")) 
        {
            dialog_man.GetComponent<DialogManager>().interact_enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        dialog_man.GetComponent<DialogManager>().interact_enabled = false;
    }


}
