using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextController : MonoBehaviour
{

    public float velocity = 3f;
    Vector3 textMoving = new Vector3(0,1);
    private bool _bool = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ativo");
    }

    // Update is called once per frame
    void Update()
    {

        // float moveX = Input.GetAxis("Horizontal");
        // float moveY = Input.GetAxis("Vertical");
        // Vector3 textMoving2 = new Vector3(moveX,moveY);
        // transform.Translate(textMoving2 * (velocity * Time.deltaTime));

        // Debug.Log(gameObject.transform.position.y);
        
        if (gameObject.transform.position.y < 5f && _bool)
        {
            transform.Translate(textMoving * (velocity * Time.deltaTime));
            
        }
        else
        {
            _bool = false;
            Vector3 te = new Vector3(0, - 2);
            transform.Translate(te * (velocity * Time.deltaTime));
        }

    }
}
