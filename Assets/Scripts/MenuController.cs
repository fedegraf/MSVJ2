using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject levelsMenu;
    public GameObject creditsMenu;


    // Play
   public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

   // Levels
    public void Niveles()
    {
        mainMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    // Credits
    public void Creditos()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    // Quit
    public void Salir()
    {
        Application.Quit();
    }

    // Back
    public void Atras()
    {
        mainMenu.SetActive(true);
        levelsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    //Levels


    public void Level1()
    {
        SceneManager.LoadScene(1);
    } 
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
    public void Level7()
    {
        SceneManager.LoadScene(7);
    }
}
