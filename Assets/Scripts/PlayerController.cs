using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce=500f;

    [SerializeField]
    private float moveForce=20f;

    [SerializeField]
    private GroundDetector groundDetector;

    private Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        if (this.isLocalPlayer && groundDetector.isTouchingGround)
        {            
            rb.AddForceAtPosition(Vector2.right * moveForce, Vector2.zero);
        }
    }

    public override void OnStartLocalPlayer()
    {
        if (isLocalPlayer)
        {
            FindObjectOfType<CameraFollow>().target = transform;
        }
    }
    void Update () {
        animator.SetFloat("xVelocity", rb.velocity.x);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isTouchingGround", groundDetector.isTouchingGround);
        if (this.isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0) && groundDetector.isTouchingGround)
            {
                rb.AddForceAtPosition(Vector2.up * jumpForce, Vector2.zero);
            }
        }
	}
}
