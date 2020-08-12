using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public int speed;
    public int jumpForce;
    [SerializeField]
    private float horizontalAxis;
    [SerializeField]
    private float verticalAxis;
    [SerializeField]
    bool canMove;
    [SerializeField]
    bool canJump;
    [SerializeField]
    bool isGrounded;

    public void StopMovement()
    {
        canMove = false;
    }

    public void ResumeMovement()
    {
        canMove = true;
    }

    void Jump()
    {
        if (canJump  && rb.velocity == new Vector3(0,0,0))
        {
            Debug.Log(rb.velocity);
            rb.AddForce(new Vector3(0, 5, 0) * jumpForce );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Terrain"))
        {
            Debug.Log("está no chão");
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("Terrain"))
        {
            Debug.Log("está no chão");
            canJump = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) { 
            horizontalAxis = Input.GetAxis("Horizontal");
            verticalAxis = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontalAxis, 0 ,verticalAxis) * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            Jump();
        }
    }
}
