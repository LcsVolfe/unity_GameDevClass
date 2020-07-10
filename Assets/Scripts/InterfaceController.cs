using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Runtime.Remoting.Activation;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Slider playerLifeSlider;
    public GameObject gameOverText;
    public Text objectivesText;
    public Text timerText;
    public Text LifeText;

    // Start is called before the first frame update
    void Start()
    {
        playerLifeSlider.maxValue = PlayerController.life;
        UpdatePlayerLifeSlider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerLifeSlider()
    {
        playerLifeSlider.value = PlayerController.life;
    }

    public void UpdateLevelObjectiveDescription(string objectives)
    {
        objectivesText.text = objectives;
    }

    public void UpdateTimer(string timer)
    {
        timerText.text = timer;
    }

    public void DisableTimer()
    {
        timerText.enabled = false;
    }
}