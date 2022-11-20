using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player size growth Power-Up.
/// </summary>

public class PowerUp1 : MonoBehaviour
{
    [SerializeField]
    private float multiplier = 2f;
    [SerializeField]
    private float duration = 1f;
    //public bool powerUpTaken;
    

    public GameObject pickupEffect; //efekti


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1")  || (other.CompareTag("Player2")) )
        {
            
            StartCoroutine( Pickup(other) );
        }


    }

    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Power up picked up!");
        
       
        //Spawn effect
        Instantiate(pickupEffect, transform.position, transform.rotation);


        //Apply effect to the player
         player.transform.localScale *= multiplier;
         
        

        //Disappear shit till wait is over
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //Wait x-time
        yield return new WaitForSeconds(duration);

        //Shrink player back to normal
         player.transform.localScale /= multiplier;
        
        
        //Remove power up object
        Destroy(gameObject);

           

    }

}