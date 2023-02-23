using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Recebe tempo de spawn de inimigos
    //Recebe tempo de partida
    //Controla o cronometro
    //Controla Gameover
    //Controla pontuação

    public static GameManager gameManagerInstance;

    //[HideInInspector]
    public float spawnTime = 3f, matchTime = 180f, score = 0;

    [HideInInspector]
    public float CurrentTime;

    [HideInInspector]
    public bool inGame = false;
    [HideInInspector]
    public bool tutorial = true;

    private void Awake()
    {
        if (gameManagerInstance == null)
            gameManagerInstance = this;

        SetTimer();
        DontDestroyOnLoad(gameManagerInstance);
    }

    private void Update()
    {
        if (inGame)
        {
            MatchTimer();
        }
    }

    public void SetTimer()
    {
        CurrentTime = matchTime;
    }

    public void MatchTimer()
    {
        CurrentTime -= Time.deltaTime;
    }
}
