using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaterTrap : MonoBehaviour {

    public int downVel;
    public int upVel;
    private CircleCollider2D c2D;
    private Rigidbody2D rb2D;
    private bool isFalling;
    private bool rewindMovement = false;
    private Vector2 velocity;
    private Vector2 initialPos;
	// Use this for initialization
	void Start () {
        
        initialPos = transform.position;
        isFalling = false;
        downVel = 10;
        upVel = 5;
        rb2D = GetComponent<Rigidbody2D>();
        
        rb2D.AddForce(new Vector2(0, 1));
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = transform.position;
      if (!isFalling && !rewindMovement)
        {
            
            isFalling = true;
            velocity = new Vector2(0, -8);
        }
      else if(rewindMovement && pos != initialPos)
        {

            isFalling = false;
            velocity = new Vector2(0, 2);
        }

        rb2D.velocity = velocity;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        string goName = collision.gameObject.name;
        if (goName == "BeaterTrapFloorCollider")
        {
            rewindMovement = true;
        } else if (goName == "BeaterTrapCeilCollider")
        {
            rewindMovement = false;
        } else if (goName != "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (isFalling && goName == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.kill();
        }
    }





}
