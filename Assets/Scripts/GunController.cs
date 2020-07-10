using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject gunBarrel;
    public AudioClip shotSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (PlayerController.life > 0 || (!GameManager.isPaused)))
        {
            Instantiate(bullet, gunBarrel.transform.position, gunBarrel.transform.rotation);
            AudioController.instance.PlayOneShot(shotSound);
        }
    }
}
