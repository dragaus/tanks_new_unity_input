using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1908 : MonoBehaviour
{
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0f;

        Vector3 move = transform.right * x + transform.up * y + transform.forward * z;

       transform.Translate(move * speed * Time.deltaTime);
    }
}
