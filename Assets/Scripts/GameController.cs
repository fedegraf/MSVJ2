using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public 
    public int currentBall;
    public GameObject victoryText;
    public GameObject gameOverText;
    public GameObject infoPanel;
    public Text pointsText;
    public int pointsToWin;

    //private
    private bool countToEndGame;
    private bool isWon = false;
    private int nextLevel;

    private void Start()
    {
        gameOverText.SetActive(false);
        victoryText.SetActive(false);

        currentBall = 0;
        countToEndGame = false;
        isWon = false;

        Time.timeScale = 1;

        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        pointsText.text = pointsToWin.ToString();
    }

    public int GetCurrentBal()
    {
        return currentBall;
    }

    private void Update()
    {
        if (countToEndGame && !isWon)
        {
            GameOver();
        }

        if (pointsToWin <= 0)
        {
            VictoryTrigger();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }

        if(!countToEndGame && !isWon)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                infoPanel.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.H))
            {
                infoPanel.SetActive(false);
            }
        }
    }

    public void AddBall()
    {
        currentBall++;
    }


    //Game over code
    public void GameOver()
    {
        Time.timeScale = 0;
        countToEndGame = true;
        infoPanel.SetActive(false);
        gameOverText.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); //Back to Main Menu.
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //Victory code
    public void VictoryRemovePoint()
    {
        pointsToWin--;
        pointsText.text = pointsToWin.ToString(); 
    }

    public void VictoryTrigger()
    {
        isWon = true;
        Time.timeScale = 0;
        infoPanel.SetActive(false);
        victoryText.SetActive(true);
    }

    public void NextLevel()
    {   
        SceneManager.LoadScene(nextLevel);
    }
}
