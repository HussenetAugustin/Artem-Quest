using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreScript : MonoBehaviour
{
    public GameObject reward;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("open", true);
    }
}
