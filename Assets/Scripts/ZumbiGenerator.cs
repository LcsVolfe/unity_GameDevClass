using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZumbiGenerator : MonoBehaviour
{
    
    
    public GameObject zumbi;
    private float timer = 0;
    public float generateTime = 2;
    
   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= generateTime)
        {
            
            //COUNTADOR DE ZUMBI
            //PRECISA REFERENCIA NO BULLET DENTRO DA TRIGEGR ONDE DESTROY O ZUMBI
            //PARA DA UM:    COUNTER--;
            
            /*
            if (counter < 2)
            {
                Instantiate(zumbi, transform.position, transform.rotation);
                counter++;
                timer = 0;
            }
            */

            Instantiate(zumbi, transform.position, transform.rotation);
            //counter++;
            timer = 0;

        }

    }
}
