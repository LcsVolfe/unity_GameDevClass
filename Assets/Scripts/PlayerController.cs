using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10;
    private Vector3 direction;
    public LayerMask groundMask;
    private Rigidbody rigidBodyPlayer;
    private Animator animatorPlayer;
    public static int life;
    public InterfaceController interfaceControllerScript;
    public AudioClip damageSound;

    public static int level;
    public static int zombiesKilled;
    public static int pickUpItensLeft;
    public static bool isFinalBossDead;

    //CONTADOR DO LEVEL
    //PARA O PRIMEIRO LEVEL, TEMOS 2 OPÇÕES, UM CONTADOR DE TEMPO || NUMERO DE KILLS DE ZUMBI
    //CONTADOR: DEPOIS DE ATINGIR UM TEMPO AUMENTA O LEVEL E DIMINUI O TEMPO DE GERAÇÃO DE ZUMBI
    //KILLS: NÃO PRECISA MANIPULAR A VELOCIDADE DE GERAÇÃO. CRIA UM CONTADOR DE KILLS AQUI E QUANDO ATINGIR AUMENTA O LVL

    //O SEGUNDO LVL EU IA DEIXA NA MÃO, MAS PEGA UM OBJETO QUALQUER E COLOCA EM UM CANTO COM UMA TAG 'LEVELUP' OU QUALQUER OUTRA
    //AI VOCE PODE USA ESSA LÓGICA

    /*
     void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.tag == "LEVELUP")
        {
            // DESTROI O OBJETO E AUMENTA O  LVL
            Destroy(colliderObject.gameObject);
            level++;
        
        
            //ESCOLHE UM SOM E COLOCA ALI SE QUISER EFEITO AO COLETA
            AudioController.instance.PlayOneShot(deathSound);
        }
    }
    */


    //O TERCEIRO LEVEL VC PODE PEGA NO ZUMBIGENERATORCONTROLLER E VE EM QUE LVL TA A CADA INSTANCIA
    // E SE FOR LVL 3 && TYPE == xx { AUMENTA FORÇA E ATACK... }


    private void Start()
    {
        Time.timeScale = 1;
        life = 100;
        level = 1;
        zombiesKilled = 0;
        pickUpItensLeft = 2;
        isFinalBossDead = false;
        rigidBodyPlayer = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(axisX, 0, axisZ);

        if (direction != Vector3.zero)
        {
            animatorPlayer.SetBool("Moving", true);
        }
        else
        {
            animatorPlayer.SetBool("Moving", false);
        }

        if (life <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameManager.ReiniciarAPartida();
            }
        }
    }

    private void FixedUpdate()
    {
        rigidBodyPlayer.MovePosition(
            rigidBodyPlayer.position + (direction * velocity * Time.deltaTime)
        );

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impact;
        if (Physics.Raycast(ray, out impact, 100, groundMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            Vector3 aimPosition = impact.point - transform.position;
            aimPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(aimPosition);

            rigidBodyPlayer.MoveRotation(newRotation);
        }
    }

    public void PlayerDamage(int damage)
    {
        life -= damage;
        // ALTERAR O VALOR DO TEXTO NO CANVAS
        interfaceControllerScript.UpdatePlayerLifeSlider();
        interfaceControllerScript.LifeText.text = "" + PlayerController.life;
        AudioController.instance.PlayOneShot(damageSound);
        
        if (life <= 0)
        {
            GameManager.Pause();
            interfaceControllerScript.gameOverText.SetActive(true);
        }
    }
}