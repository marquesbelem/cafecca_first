using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    private Transform playerTransf;
    [SerializeField]
    private float cameraVelocity = 80f;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransf = GetComponent<Transform>();    
    }

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * cameraVelocity;
        playerTransf.Rotate(Vector3.up * mouseX);
    }
}
