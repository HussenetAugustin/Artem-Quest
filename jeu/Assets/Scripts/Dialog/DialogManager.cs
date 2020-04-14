using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogManager : MonoBehaviour
{
    public GameObject dialogContainer;
    public TextMeshProUGUI Nom;
    public Text DialogText;
    private Queue<string> dialogs;
    private float vitesse;
    private bool next;
    public float vitesseInit;
    private GameObject player;

    private void Start()
    {
        vitesse = vitesseInit;
        next = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartDialog(Dialog dialog, string name)
    {
        dialogContainer.SetActive(true);
        Nom.text = name;
        player.GetComponent<PlayerMovement>().currentState = PlayerState.speaking;
        dialogs = new Queue<string>();
        foreach (string s in dialog.m_sentences)
        {
            dialogs.Enqueue(s);
        }
        DialogText.text = "";
        next = false;
        StartCoroutine(CoroutineText(dialogs.Dequeue()));
        //DialogText.text = dialogs.Dequeue();
    }

    public void ContinueDialog()
    {
        if (dialogs.Count > 0 && next)
        {
            DialogText.text = "";
            next = false;
            StartCoroutine(CoroutineText(dialogs.Dequeue()));
            //DialogText.text = dialogs.Dequeue();
        }
        else if (!next)
        {
            vitesse = 0;
        }
        else
        {
            EndDialog();
        }
    }

    public void EndDialog()
    {
        StopAllCoroutines();
        dialogContainer.SetActive(false);
        DialogText.text = "";
        dialogs.Clear();
        player.GetComponent<PlayerMovement>().currentState = PlayerState.walk;
    }

    IEnumerator CoroutineText(string send)
    {
        char[] c = send.ToCharArray();
        foreach(char a in c)
        {
            DialogText.text += a;
            if(vitesse == 0)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(vitesse);
            }
        }
        next = true;
        vitesse = vitesseInit;
    }

}
