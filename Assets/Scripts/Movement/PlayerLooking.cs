using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    Transform playerTransf;
    [SerializeField]
    float cameraVelocity = 80f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransf = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraVelocity;
        playerTransf.Rotate(Vector3.up * mouseX);
    }
}
