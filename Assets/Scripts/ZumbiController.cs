using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZumbiController : MonoBehaviour
{

    public GameObject player;
    public float velocity = 5;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(newRotation);
        
        if (distance > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(
                GetComponent<Rigidbody>().position + direction.normalized * (velocity * Time.deltaTime)
            );
            GetComponent<Animator>().SetBool("Attacking", false);

        }
        else
        {
            GetComponent<Animator>().SetBool("Attacking", true);
        }
    }

    void PlayerAttack()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().gameOverText.SetActive(true);
        player.GetComponent<PlayerController>().dead = true;
    }
}