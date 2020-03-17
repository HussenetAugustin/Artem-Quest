using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed;
    public float maxTime;


    private Vector3 change;
    bool des;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debut");
        des = false;
        //this.transform.position = player.GetComponent<Transform>().transform.position;
        //this.transform.rotation = player.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += change * speed * Time.deltaTime;
        if (!des)
        {
            des = true;
            StartCoroutine(destroyArrow(maxTime));
        }
    }

    public void setChange(float x, float y)
    {
        change.x = x;
        change.y = y;
        change.Normalize();
        var rotationVector = transform.rotation.eulerAngles;
        if (x > 0 && y > 0) rotationVector.z = 135;
        else if (x > 0 && y < 0) rotationVector.z = 45;
        else if (x < 0 && y > 0) rotationVector.z = 225;
        else if (x < 0 && y < 0) rotationVector.z = 315;
        else if (x > 0) rotationVector.z = 90;
        else if (y > 0) rotationVector.z = 180;
        else if (x < 0) rotationVector.z = 270;
        else rotationVector.z = 0;
        transform.rotation = Quaternion.Euler(rotationVector);

    }


    private IEnumerator destroyArrow(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            //StopAllCoroutines();
            //other.GetComponent<Enemy>().TakeDamage(1);
            other.GetComponent<Enemy>().Knock(other.GetComponent<Rigidbody2D>(), 1f, 1);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("breakable"))
        {
            //Debug.Log("Coucou");
            other.GetComponent<potScript>().Smash();
            Destroy(this.gameObject);
        }
    }
}
