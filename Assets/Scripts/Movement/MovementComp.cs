using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComp : MonoBehaviour
{
    private CharacterController chController;

    [SerializeField]
    private float verticalVelocity;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float maxFallingSpeed;
    [SerializeField]
    private float moveVelocity;
    private Vector3 moveVector;
    [SerializeField]
    private float jumpForce;

    //TODO: Automated configs from an ScriptableObj.

    // Start is called before the first frame update
    void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetAxis("Jump") > 0)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * moveVelocity * Time.deltaTime;
        moveVector.z = Input.GetAxis("Vertical") * moveVelocity * Time.deltaTime;
        moveVector.y = verticalVelocity * maxFallingSpeed;

        chController.Move(moveVector);        
    }
}
