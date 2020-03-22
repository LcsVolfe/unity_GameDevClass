using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    Vector3 distCameraPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        distCameraPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distCameraPlayer;
    }
}
