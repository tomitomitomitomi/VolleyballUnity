using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ignorte phisics Ignores ball phisics in Volleyball scenes towards an invisible wall.
/// </summary>

public class IgnorePhisics : MonoBehaviour {

    [SerializeField] private Collider2D ball;

    [SerializeField] private Collider2D inWall;

    /// <summary>
    /// Ignores the phisics of the ball on the start towards an invisible wall.
    /// </summary>
    void Start () {


        Physics2D.IgnoreCollision(ball, inWall);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
