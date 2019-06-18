using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CatControl : MonoBehaviour {

	float dirX;
	public float moveSpeed , jumpForce;
	Rigidbody2D rb;
    Transform tf;
	bool facingRight = true;
    bool jump_or_not = true;
	Vector3 localScale;
    /*
    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        
    }

    private void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizonal");
        if(Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 700f);
        }
    }*/
    
	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
        tf = GetComponent<Transform>();
        jumpForce = 25000f;
        moveSpeed = 200f;
    }
	
	// Update is called once per frame
	void Update () {
		dirX = CrossPlatformInputManager.GetAxis ("Horizontal");
        if (CrossPlatformInputManager.GetButtonDown("Jump")) DoJump();
    }
    


	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
	}
    public void DoJump()
    {
        if(jump_or_not)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump_or_not = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jump_or_not = false;
    }

    void LateUpdate()
	{		
		CheckWhereToFace ();
	}

	void CheckWhereToFace ()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;
		
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
		
		transform.localScale = localScale;
	}
    
}
