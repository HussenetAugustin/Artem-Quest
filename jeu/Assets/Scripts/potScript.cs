using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potScript : MonoBehaviour
{
    private Animator anim;
    private bool willGift;
    private bool gifted;
    public GameObject gift;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gifted = false;
        willGift = Random.Range(0, 100) < 50 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());

    }

    IEnumerator breakCo()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (gift != null && !gifted && willGift)
        {
            Instantiate(gift, transform.position, Quaternion.identity);
        }
        if (explosion != null && !gifted)
        {
            GameObject gameObj = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObj, 0.35f);
        }
        gifted = true;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

}
