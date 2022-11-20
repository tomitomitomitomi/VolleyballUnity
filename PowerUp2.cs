using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// Ball speed boost Power-Up.
/// </summary>

public class PowerUp2 : MonoBehaviour
{
    public float multiplier2 = 2f;
    public float duration2 = 1f;

    public GameObject pickupEffect2; //efekti

    void OnTriggerEnter2D2(Collider2D other)
    {
        if (other.CompareTag("Player1") || (other.CompareTag("Player2")))
        {
            StartCoroutine(Pickup2(other));
        }

    }

    IEnumerator Pickup2(Collider2D player)
    {
        Debug.Log("Power up picked up!");

        //Spawn effect
        Instantiate(pickupEffect2, transform.position, transform.rotation);

        //Apply effect to the ball
      //  BallBehaviour.minSpeed *= multiplier2;

        //Disappear shit till wait is over
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //Wait x-time
        yield return new WaitForSeconds(duration2);

        //Ball speed normalizing
      //  BallBehaviour.minSpeed /= multiplier2;

        //Remove power up object
        Destroy(gameObject);
       
    }
}