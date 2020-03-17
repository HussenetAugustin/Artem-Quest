using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle,
    speaking
}

public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;
    public bool canInteract;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public GameObject inventoryCanvas;

    public InputPlayer inputs;
    public GameObject arrowFired;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
        currentHealth.RuntimeValue = currentHealth.initialValue;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Shoot"))
        {
            fire();
        }
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.interact && currentState != PlayerState.stagger && currentState != PlayerState.speaking)
        {
            StartCoroutine(AttackCo());
        }
        if (currentState == PlayerState.walk || currentState == PlayerState.interact || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void MoveCharacter()
    {
        change.Normalize();
        playerRigidbody.MovePosition(
                transform.position + change * speed * Time.deltaTime
            );
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        if (currentHealth.RuntimeValue > 0)
        {
            playerHealthSignal.Raise();
            StartCoroutine(KnockCo(knockTime));
        } else
        {
            playerHealthSignal.Raise();
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("Main Scene");
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (playerRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            playerRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
        }
    }

    public void fire()
    {
        Vector3 position = transform.position;
        position.x += animator.GetFloat("moveX")/2;
        position.y += animator.GetFloat("moveY")/2;
        GameObject arrow = Instantiate(arrowFired, position, Quaternion.identity);
        arrow.GetComponent<ArrowScript>().setChange(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
    }


}
