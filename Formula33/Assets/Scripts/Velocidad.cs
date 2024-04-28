using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocidad : MonoBehaviour
{
    public Slider barra;

    private float velocidadSubida;
    private float velocidadBajada;
    private float timeToFall;

    public float velocidadSubidaEasy;
    public float velocidadBajadaEasy;
    public float timeToFallEasy;

    public float velocidadSubidaMedium;
    public float velocidadBajadaMedium;
    public float timeToFallMedium;

    public float velocidadSubidaHard;
    public float velocidadBajadaHard;
    public float timeToFallHard;


    public miniGame minigame;
    float timerToFall;
    bool secondPlayer;
    public int adaptableDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        timerToFall = 0;

        adaptableDifficulty = minigame.controlador.adaptableDifficulty;

        if (adaptableDifficulty == 0)
        {
            velocidadBajada = velocidadBajadaEasy;
            velocidadSubida = velocidadSubidaEasy;
            timeToFall = timeToFallEasy;
}
        else if (adaptableDifficulty == 1)
        {
            velocidadBajada = velocidadBajadaMedium;
            velocidadSubida = velocidadSubidaMedium;
            timeToFall = timeToFallMedium;
        }
        else if (adaptableDifficulty >= 2)
        {
            velocidadBajada = velocidadBajadaHard;
            velocidadSubida = velocidadSubidaHard;
            timeToFall = timeToFallHard;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timerToFall -= Time.deltaTime;
        if (timerToFall <= 0)
        {
            barra.value -= velocidadBajada * Time.deltaTime;
        }
        /*else
        {
            barra.value += velocidadSubida * Time.deltaTime;
        }*/
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                barra.value += velocidadSubida;
                timerToFall = timeToFall;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                barra.value += velocidadSubida;
                timerToFall = timeToFall;
            }
        }
        
        if (barra.value >= barra.maxValue)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        minigame.Finished();
    }
}
