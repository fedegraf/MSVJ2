﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    //private
    private Vector3 spawnPos;
    private float newSpawnDuration = 5f;
    private BallController ballController;
    

    //public
    public GameController gameController;

    //serialized
    [SerializeField] private Queue<GameObject> ballPrefabs;
    [SerializeField] private Queue<Sprite> ballSprites;
    [SerializeField] private GameObject normalBallPrefab;
    [SerializeField] private GameObject dropBallPrefab;
    [SerializeField] private GameObject explosiveBallPrefab;
    [SerializeField] private GameObject bouncyBallPrefab;

    [SerializeField] private Sprite normalBallSprite;
    [SerializeField] private Sprite dropBallSprite;
    [SerializeField] private Sprite explosiveBallSprite;
    [SerializeField] private Sprite bouncyBallSprite;

    [SerializeField] private Image nextBallImage;
    #region Singleton
    public static BallSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        ballPrefabs = new Queue<GameObject>();
        ballSprites = new Queue<Sprite>();
        switch (SceneManager.GetActiveScene().buildIndex)   // Hacemos un switch con el nivel en el que estemos
        {
            case 1:    
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);        // Agregamos a la cola las pelotas que queramos en cada caso
                ballPrefabs.Enqueue(normalBallPrefab);


                ballSprites.Enqueue(normalBallSprite);        // Agregamos a la cola los sprites para ver cual será la siguiente, iguales a los prefabs pero sin el primero
                ballSprites.Enqueue(normalBallSprite);
                break;
            case 2:    
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(bouncyBallPrefab);

                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(bouncyBallSprite);
                break;
            case 3:
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(bouncyBallPrefab);
                ballPrefabs.Enqueue(bouncyBallPrefab);

                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(bouncyBallSprite);
                ballSprites.Enqueue(bouncyBallSprite);
                break;
            case 4:
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(bouncyBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);

                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(bouncyBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                break;
            case 5:
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);

                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                break;
            case 6:
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(dropBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);

                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(dropBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                break;
            case 7:
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(explosiveBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);
                ballPrefabs.Enqueue(normalBallPrefab);

                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(explosiveBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                ballSprites.Enqueue(normalBallSprite);
                break;

        }
        spawnPos = transform.position;
        SpawnNewBall(); // spawnea la primera sola
    }

    public void SpawnNewBall()
    {
        if (ballPrefabs.Count > 0) //si hay pelotas para que spawneen
        {
            GameObject ball = Instantiate(ballPrefabs.Peek(), spawnPos, Quaternion.identity);  //Spawneamos la que está primera en la cola
            ball.name = ballPrefabs.Peek().name;
            if (ballSprites.Count > 0) nextBallImage.sprite = ballSprites.Peek();
            else nextBallImage.color = new Color(255, 255, 255, 0);
            ballPrefabs.Dequeue();    // Acá la desacolamos entonces la próxima vez que se ejecute será la siguiente en la cola
            if(ballSprites.Count > 0) ballSprites.Dequeue();
            gameController.AddBall();
        }
        else
        {
            gameController.GameOver();
        }
    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewBall", newSpawnDuration);
    }

}
