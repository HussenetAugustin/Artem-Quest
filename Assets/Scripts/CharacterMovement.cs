using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Vector3 V;
    private float dirForward;
    private float dirRight;
    // Start is called before the first frame update
    void Start()
    {
        dirForward = 1;
        dirRight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float amp = Mathf.Sqrt(v * v + h * h);


        if (v>0 && h==0)
        {
            dirForward = 1;
            dirRight = 0;
        }
        if (v<0 && h==0)
        {
            dirForward = -1;
            dirRight = 0;
        }
        if (h>0 && v==0)
        {
            dirRight = 1;
            dirForward = 0;
        }
        if (h<0 && v==0)
        {
            dirRight = -1;
            dirForward = 0;
        }


        transform.Translate(speed*h, speed*v,0);
        animator.SetFloat("Amplitude", amp);
        if (amp>0.2)
        {
            animator.SetFloat("Forward", h);
            animator.SetFloat("Right", v);
        }
        
        if (amp == 0)
        {
            animator.SetFloat("Dir_Forward", dirForward);
            animator.SetFloat("Dir_Right", dirRight);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetFloat("Amplitude", 0);
        animator.SetFloat("Forward", 0);
        animator.SetFloat("Right", 0);
    }
}
