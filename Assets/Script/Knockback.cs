using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; //represents force which player knocks back enemy
    public float knockTime;
    public float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<pot>().Smash();
        }

        if (other.gameObject.CompareTag("enemy") && other.isTrigger || other.gameObject.CompareTag("Player"))//if object we swung at has tag of enemy
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();//This is declaring a rigid body so enemy is = to rigid body
            if(hit != null) //if there are a rigid body
            {
                Vector2 difference = hit.transform.position - transform.position;//apply the force formula (first they find the distance between the enemy and player on contact)
                difference = difference.normalized * thrust; //then with the difference of distance we times that by thrust and normalized which is turning a vector into a length of one
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerController>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerController>().Knock(knockTime, damage);
                    }
                }

            }
        }
    }

}
