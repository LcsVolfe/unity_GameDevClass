using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiGenerator : MonoBehaviour
{

    public GameObject zumbi;
    private float timer = 0;
    public float generateTime = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= generateTime)
        {
            Instantiate(zumbi, transform.position, transform.rotation);
            timer = 0;
        }

    }
}
