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

    public AudioSource audioSource;
    public List<AudioClip> velocitySounds;
    public GameObject aleronRojo;
    public GameObject aleronVerde;
    public Animator animadorRojo;
    public Animator animadorVerde;

    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        timerToFall = 0;
        if (!secondPlayer)
        {
            aleronRojo.SetActive(true);
            aleronVerde.SetActive(false);
        }
        else
        {
            aleronRojo.SetActive(false);
            aleronVerde.SetActive(true);
        }
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
            animadorRojo.SetBool("going", false);
            animadorVerde.SetBool("going", false);
        }
        else
        {
            animadorRojo.SetBool("going", true);
            animadorVerde.SetBool("going", true);
        }
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                barra.value += velocidadSubida;
                timerToFall = timeToFall;
                PlayVelocitySound();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                barra.value += velocidadSubida;
                timerToFall = timeToFall;
                PlayVelocitySound();
            }
        }
        
        if (barra.value >= barra.maxValue)
        {
            WinGame();
        }
    }
    public void PlayVelocitySound()
    {
        int i = Random.Range(0, velocitySounds.Count);
        audioSource.clip = velocitySounds[i];
        audioSource.Play();
    }
    void WinGame()
    {
        minigame.Finished();
    }
}
