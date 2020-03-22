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

        if (distance > 2)
        {
            Vector3 direction = player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(
                GetComponent<Rigidbody>().position + direction.normalized * (velocity * Time.deltaTime)
            );
            
            Quaternion newRotation = Quaternion.LookRotation(direction);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}