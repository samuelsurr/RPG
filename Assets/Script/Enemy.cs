using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState//enum is like a bool value but instead of true or false its a number (mainly used to make states
{
    idle,
    walk,
    attack,
    stagger
}



public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName; // cant call it name since its a reserved word in MonoBehavior
    public int baseAttack;
    public float moveSpeed;
    //this is the overall thing that all enemies should have
    // you then can connect this enemy code to any other actual enemy by putting a new C# Enemy instead of MonoBehavior
    // This is called inheritance.
    //polymorphisim just means something has the attribute of multiple things (12/28/23) ep 16

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)//this is for stopping knockback or they will fly forever
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;

        }
    }

}
