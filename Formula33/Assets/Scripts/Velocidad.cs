using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocidad : MonoBehaviour
{
    public Slider barra;
    public float velocidadBajada;
    public float velocidadSubida;
    public float timeToFall;
    public miniGame minigame;
    float timerToFall;
    bool secondPlayer;
    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        timerToFall = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerToFall -= Time.deltaTime;
        if (timerToFall <= 0)
        {
            barra.value -= velocidadBajada * Time.deltaTime;
        }
        else
        {
            barra.value += velocidadSubida * Time.deltaTime;
        }
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                timerToFall = timeToFall;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
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
