using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    public Signal healthSignal;
    public FloatValue maxHealth;
    public EnemyState currentState;
    public FloatValue health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject[] giftList;


    public void TakeDamage(float damage)
    {
        health.RuntimeValue -= damage;
        healthSignal.Raise();
        if (health.RuntimeValue <= 0)
        {
            this.gameObject.SetActive(false);
            Instantiate(giftList[0], transform.position, Quaternion.identity);

        }
    }

    public void Knock(Rigidbody2D myrigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myrigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myrigidBody, float knockTime)
    {
        if (myrigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myrigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
        }
    }

}
