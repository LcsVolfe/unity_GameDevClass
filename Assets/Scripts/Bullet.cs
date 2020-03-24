using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(
            position: GetComponent<Rigidbody>().position +
                      transform.forward * (velocity * Time.deltaTime)
        );
    }

    void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.tag == "enemy")
        {
            Destroy(colliderObject.gameObject);
        }

        Destroy(gameObject);

    }
}