using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public bool dialog_enabled = false;
    public GameObject canvas;
    public GameObject title;
    public GameObject next;
    public Text text_holder;
    public bool interact_enabled = false;
    private Queue dialogue;
    private Queue door;
    private string current;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue();
        string d1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do\n eiusmod tempor incididunt ut labore et dolore magna aliqua. \n Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris \n nisi ut aliquip ex ea commodo consequat.";
        string d2 = "At vero eos et accusamus et iusto odio dignissimos ducimus qui \n blanditiis praesentium voluptatum deleniti atque corrupti quos \n dolores et quas molestias excepturi sint occaecati \ncupiditate non provident, similique sunt in culpa qui \n officia deserunt mollitia animi.";
        string d3 = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem \n accusantium doloremque laudantium, totam rem aperiam, eaque ipsa \n quae ab illo inventore veritatis et quasi architecto beatae vitae \n dicta sunt explicabo.";
        dialogue.Enqueue(d1);
        dialogue.Enqueue(d2);
        dialogue.Enqueue(d3);
        current = (string) dialogue.Dequeue();
        text_holder.text = current;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.GetComponent<Image>().enabled = dialog_enabled;
        title.GetComponent<Text>().enabled = dialog_enabled;

        if (dialogue.Count > 0) { 
        next.GetComponent<Image>().enabled = dialog_enabled;
        }

        else
        {
            next.GetComponent<Image>().enabled = false;
        }

        text_holder.enabled = dialog_enabled;

        if (Input.GetButtonDown("Pass_Dialogue") && dialog_enabled && dialogue.Count>0)
        {
            current = (string)dialogue.Dequeue();
            text_holder.text = current;
        }

    }
}
