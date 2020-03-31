using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public Text text_holder;
    public GameObject canvas;
    private Queue hint_queue;
    private bool is_visible;
    private string current;
    // Start is called before the first frame update
    void Start()
    {
        hint_queue = new Queue();
        string h0 = "Appuyez sur Maj gauche pour de nouvelles indications.";
        string h1 = "Appuyez sur F pour activer / désactiver la fenêtre d'indications.";
        string h2 = "Utilisez Z,Q,S,D pour vous déplacer dans la pièce.";
        string h3 = "Vous pouvez intéragir avec les décors ou personnages avec E.";
        string h5 = "Éloignez vous pour cesser une interaction.";
        string h4 = "Appuyez sur Espace pour faire avancer un dialogue.";
        hint_queue.Enqueue(h0);
        hint_queue.Enqueue(h1);
        hint_queue.Enqueue(h2);
        hint_queue.Enqueue(h3);
        hint_queue.Enqueue(h4);
        hint_queue.Enqueue(h5);

        text_holder.text = "";
        is_visible = true;
        text_holder.text = (string) hint_queue.Dequeue();
        current = text_holder.text;
    }

    // Update is called once per frame
    void Update()
    { 

       if (Input.GetButtonDown("Hide/Show_Hint"))
        {
            is_visible = !is_visible;
            canvas.GetComponent<Image>().enabled = is_visible;
            if (is_visible)
            {
                text_holder.text = current;
            }
            else
            {
                text_holder.text = "";
            }
        }
        
        
        if (Input.GetButtonDown("New_Hint") && is_visible && hint_queue.Count>0)
        {
            text_holder.text = (string) hint_queue.Dequeue();
            current = text_holder.text;
        }

    }
}
