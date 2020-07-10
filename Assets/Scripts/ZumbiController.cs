using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZumbiController : MonoBehaviour
{

    public GameObject player;
   // public InterfaceController interfaceControllerScript;
    public float velocity = 5;
    
    //VARIAVEIS AUXILIARES
    public int minAtack = 10;
    public int maxAtack = 15;
    
    
    private Rigidbody rigidBodyZumbi;
    private Animator animatorZumbi;
    
    void Start()
    {
        player = GameObject.FindWithTag("player");
        int zumbiType = Random.Range(1, 28);
        
        //CONFIGURAÇÃO DAS CLASSES DE ZUMBI
        //DEFINE O MIN MAX DE ATACK E VELOCIDADE DENTRO DE CADA ZUMBITYPE
        //PARA O BOSS SERIA SETA UM TYPE E AGREGAR VELOCIDADE E FORÇA...
        //O TAMANHO DA PRA TENTA FAZER ALGO
        int min = 10;
        int max = 15;

        
        //VOCE PODE PEGA A REFERENCIA DO PLAYER CONTROLLER AQUI E VER O LVL
        //   player.level
        
        if(zumbiType == 10) { velocity = 9; min = 7; max = 12; }
        else if(zumbiType == 12) { velocity = 7; min = 5; max = 15; }
        else if(zumbiType == 20) { velocity = 4; min = 3; max = 10; }
        else if(zumbiType == 2) { velocity = 6; min = 20; max = 30; }
        else if(zumbiType == 5) { velocity = 3; min = 24; max = 40; }
        else if(zumbiType == 15) { velocity = 13; min = 9; max = 13; }
        else if(zumbiType == 25) { velocity = 3; min = 15; max = 18; }
        else if(zumbiType == 1) { velocity = 8; min = 7; max = 16; }

        minAtack = min;
        maxAtack = max;

        transform.GetChild(zumbiType).gameObject.SetActive(true);
        rigidBodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        rigidBodyZumbi.MoveRotation(newRotation);


        //SE O PLAYER ESTIVER LONGE O ZUMBI NAO VAI DE ATRAS
        if (distance < 30)
        {
            rigidBodyZumbi.MovePosition(
                rigidBodyZumbi.position + direction.normalized * (velocity * Time.deltaTime)
            );
        }
        
        if (distance > 2.5)
        {
            animatorZumbi.SetBool("Attacking", false);
        }
        else
        {
            animatorZumbi.SetBool("Attacking", true);
        }
    }

    void PlayerAttack()
    {
        // O DAMAGE FICOU NESSAS VARIAVEIS AUXILIARES
        int damage = Random.Range(minAtack, maxAtack);
        player.GetComponent<PlayerController>().PlayerDamage(damage);

        // ALTERAR O VALOR DO TEXTO NO CANVAS
        //interfaceControllerScript.GetComponent<InterfaceController>().LifeText.text = "" + PlayerController.life;
        //player.GetComponent<PlayerController>().lifeText.text = "" + PlayerController.life; //"Vida: " + player.GetComponent<PlayerController>().life;
    }
}