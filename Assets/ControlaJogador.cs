using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public float velocity = 10;
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(axisX, 0, axisZ);
        
        transform.Translate(direction * velocity * Time.deltaTime);

    }
}
