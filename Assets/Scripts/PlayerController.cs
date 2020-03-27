using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10;
    private Vector3 direction;
    public LayerMask groundMask;
    public GameObject gameOverText;
    public bool dead = false;
    private Rigidbody rigidBodyPlayer;
    private Animator animatorPlayer;
    
    private void Start()
    {
        Time.timeScale = 1;
        rigidBodyPlayer = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(axisX, 0, axisZ);

        if (direction != Vector3.zero)
        {
            animatorPlayer.SetBool("Moving", true);
        }
        else
        {
            animatorPlayer.SetBool("Moving", false);
        }

        if (dead == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("first_scene");
            }
        }
    }

    private void FixedUpdate()
    {
        rigidBodyPlayer.MovePosition(
            rigidBodyPlayer.position + (direction * velocity * Time.deltaTime)
        );

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        RaycastHit impact;
        if (Physics.Raycast(ray, out impact, 100, groundMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            Vector3 aimPosition = impact.point - transform.position;
            aimPosition.y = transform.position.y;
            
            Quaternion newRotation = Quaternion.LookRotation(aimPosition);
            
            rigidBodyPlayer.MoveRotation(newRotation);
        }
    }
}