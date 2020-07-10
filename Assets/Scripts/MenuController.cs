using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    //private float _teste = 1;
    public string scene = "menu_scene";
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeGame()
    {
        Debug.Log("Fechou!");
        Application.Quit();
    }

    public void openAbout()
    {
        SceneManager.LoadScene("about_scene");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void openMenu()
    {
        SceneManager.LoadScene("menu_scene");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void playGame()
    {
        SceneManager.LoadScene("first_scene");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void chageScene(string scene)
    {
        SceneManager.LoadScene(scene);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
