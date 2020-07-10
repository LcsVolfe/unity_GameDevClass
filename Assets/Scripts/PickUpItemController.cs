using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            Destroy(gameObject);
            PlayerController.pickUpItensLeft--;
        }
    }
}
