using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    private PlayerController playerControllerScript;
    public Slider playerLifeSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("player").GetComponent<PlayerController>();
        playerLifeSlider.maxValue = playerControllerScript.life;
        UpdatePlayerLifeSlider();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdatePlayerLifeSlider()
    {
        playerLifeSlider.value = playerControllerScript.life;

    }
}
