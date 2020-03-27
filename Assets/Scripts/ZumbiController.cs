using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZumbiController : MonoBehaviour
{

    public GameObject player;
    public float velocity = 5;
    private Rigidbody rigidBodyZumbi;
    private Animator animatorZumbi;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");
        int zumbiType = Random.Range(1, 28);
        transform.GetChild(zumbiType).gameObject.SetActive(true);
        rigidBodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
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
        rigidBodyZumbi.MoveRotation(newRotation);
        
        if (distance > 2.5)
        {
            rigidBodyZumbi.MovePosition(
                rigidBodyZumbi.position + direction.normalized * (velocity * Time.deltaTime)
            );
            animatorZumbi.SetBool("Attacking", false);

        }
        else
        {
            animatorZumbi.SetBool("Attacking", true);
        }
    }

    void PlayerAttack()
    {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().gameOverText.SetActive(true);
        player.GetComponent<PlayerController>().dead = true;
    }
}