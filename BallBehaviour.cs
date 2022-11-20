using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class handles physics of ball
/// </summary>
public class BallBehaviour : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField]
    private float hitForce;
    [SerializeField]
    private float ballLift;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float minSpeed;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    /// <summary>
    /// Adding velocity to ball when colliding with hammer collider
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
             Vector2 dir = new Vector2 (rb2d.velocity.x, ballLift);
            rb2d.AddForce(dir * hitForce, ForceMode2D.Impulse );
            //rb2d.velocity *= -ballSpeed;
        }
    }



    // Update is called once per frame
    void FixedUpdate () {

        //Limiting ball max speed
		if (rb2d.velocity.magnitude > maxSpeed){
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
        //Limiting ball minimun speed
        if (rb2d.velocity.magnitude < minSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * minSpeed;
        }
	}
}
