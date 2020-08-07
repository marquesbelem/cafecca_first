using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exemplo : MonoBehaviour
{
    public Text text;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "texto";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(transform.up * 10);
        }
    }
}
