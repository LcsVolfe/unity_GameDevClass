using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject interfaceController;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;

    public static bool isPaused = false;
    private float timer;

    void Start()
    {
        Level1.SetActive(true);
    }

    void Update()
    {
        //  Controlador do botão de pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        // Gerenciador de fases
        switch (PlayerController.level)
        {
            case 1:

                //  Controla o temporizador do primeiro level
                timer += Time.deltaTime;
                string seconds = (timer % 60).ToString("00");
                string minutes = ((int)timer / 60).ToString("00");
                string timerText = minutes + ":" + seconds;
                interfaceController.GetComponent<InterfaceController>().UpdateTimer(timerText);

                //  Gerencia o texto do objetivo
                interfaceController.GetComponent<InterfaceController>().UpdateLevelObjectiveDescription("Sobreviva por um minuto ou \n\n Mate 20 zumbis (" + PlayerController.zombiesKilled + "/20)");

                // Verifica se os requisitos do level foram cumpridos
                if (PlayerController.zombiesKilled >= 20 || timer >= 60.0f)
                {
                    LevelUp();
                    Level1.SetActive(false);
                    Level2.SetActive(true);
                    interfaceController.GetComponent<InterfaceController>().DisableTimer();
                }

                break;

            case 2:
                interfaceController.GetComponent<InterfaceController>().UpdateLevelObjectiveDescription("Colete os itens. \nFaltam " + PlayerController.pickUpItensLeft);

                if (PlayerController.pickUpItensLeft == 0)
                {
                    LevelUp();
                    Level2.SetActive(false);
                    Level3.SetActive(true);
                }
                break;

            case 3:
                interfaceController.GetComponent<InterfaceController>().UpdateLevelObjectiveDescription("Mate o boss final!");

                if (PlayerController.isFinalBossDead)
                {
                    //FimDeJogo()
                    Level3.SetActive(false);
                }
                break;
        }
    }

    public static void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    private void LevelUp()
    {
        PlayerController.level++;
        //isUpdated = false;
    }

    public static void ReiniciarAPartida()
    {
        SceneManager.LoadScene("first_scene");
    }
}
