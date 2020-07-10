using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20;
    private Rigidbody rigidBodyBullet;
    public AudioClip deathSound;
    public GameObject zumbiGenerator; //= GameObject.FindGameObjectWithTag("");

    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyBullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBodyBullet.MovePosition(
            position: rigidBodyBullet.position +
                      transform.forward * (velocity * Time.deltaTime)
        );
    }

    void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.tag == "enemy")
        {
            PlayerController.zombiesKilled++;
            Destroy(colliderObject.gameObject);
            AudioController.instance.PlayOneShot(deathSound);
        }

        Destroy(gameObject);

    }
}