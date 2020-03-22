using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10;
    private Vector3 direction;
    
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(axisX, 0, axisZ);

        if (direction != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + (direction * velocity * Time.deltaTime)
        );
    }
}