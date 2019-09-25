using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; // Main
    private Rigidbody2D myRigidbody;

    public float jumpSpeed; //jump

    public Transform groundCheck; //ground
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded; // circle around feet

    private Animator myAnim;
    // 2D NEVER CHANGE Z ON 2D**********
    // Use this for initialization

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;

        void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        respawnPosition = transform.position; // respawns at start point

        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //checks if player is on ground


        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f); // uses move speed horiztonal +
            transform.localScale = new Vector3(1f, 1f, 1f);
        }  else if (Input.GetAxis("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f); // uses move speed horizontal -
            transform.localScale = new Vector3(-1f, 1f, 1f); // turns the scale of the player when you go left, just x value
        }  else {
            myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded) // if player is on ground, you can jump.
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f); // Jump function
        }
        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x)); // turns - num to + num
        myAnim.SetBool("Grounded", isGrounded);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);

            //transform.position = respawnPosition;

            theLevelManager.Respawn();

        }
        if(other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }
}
