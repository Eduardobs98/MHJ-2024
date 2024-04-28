using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pesca : MonoBehaviour
{
    public Slider barra;
    float timerToFall;
    public RawImage zonaBuena;
    float destino;
    bool arriba;
    public miniGame minigame;
    bool secondPlayer;
    float timerToWin;
    public Image gasofa;
    public AudioSource sonidoDeLlenado;
    public AudioSource sonidoFinal;
    public Color wrongColor;
    public Color rightColor;

    private float velocidadBajada;
    private float velocidadSubida;
    private float timeToFall;
    private float tamanioZonaBuena;
    private float velMovimiento;
    private float timeToWin;

    public float velocidadBajadaEasy;
    public float velocidadSubidaEasy;
    public float timeToFallEasy;
    public float tamanioZonaBuenaEasy;
    public float velMovimientoEasy;
    public float timeToWinEasy;

    public float velocidadBajadaMedium;
    public float velocidadSubidaMedium;
    public float timeToFallMedium;
    public float tamanioZonaBuenaMedium;
    public float velMovimientoMedium;
    public float timeToWinMedium;

    public float velocidadBajadaHard;
    public float velocidadSubidaHard;
    public float timeToFallHard;
    public float tamanioZonaBuenaHard;
    public float velMovimientoHard;
    public float timeToWinHard;
    public int adaptableDifficulty;


    // Start is called before the first frame update
    void Start()
    {

        adaptableDifficulty = minigame.controlador.adaptableDifficulty;
        zonaBuena.color = wrongColor;
        if (adaptableDifficulty == 0)
        {
            velocidadBajada = velocidadBajadaEasy;
            velocidadSubida = velocidadSubidaEasy;
            timeToFall = timeToFallEasy;
            tamanioZonaBuena = tamanioZonaBuenaEasy;
            velMovimiento = velMovimientoEasy;
            timeToWin = timeToWinEasy;
        }
        else if (adaptableDifficulty == 1)
        {
            velocidadBajada = velocidadBajadaMedium;
            velocidadSubida = velocidadSubidaMedium;
            timeToFall = timeToFallMedium;
            tamanioZonaBuena = tamanioZonaBuenaMedium;
            velMovimiento = velMovimientoMedium;
            timeToWin = timeToWinMedium;
        }
        else if (adaptableDifficulty >= 2)
        {
            velocidadBajada = velocidadBajadaHard;
            velocidadSubida = velocidadSubidaHard;
            timeToFall = timeToFallHard;
            tamanioZonaBuena = tamanioZonaBuenaHard;
            velMovimiento = velMovimientoHard;
            timeToWin = timeToWinHard;
        }


        barra.value = 0;
        timerToFall = 0;
        timerToWin = 0;
        zonaBuena.rectTransform.localScale = new Vector3(1, tamanioZonaBuena, 1);
        zonaBuena.rectTransform.pivot =new Vector2(0.5f, Random.Range(0f,1f));
        destino = Random.Range(0f, 1f);
        secondPlayer = minigame.controlador.secondPlayer;
        if (destino< zonaBuena.rectTransform.pivot.y)
        {
            arriba = false;
        }
        else
        {
            arriba = true;
        }



    }

    // Update is called once per frame
    void Update()
    {
        timerToFall -= Time.deltaTime;
        if(timerToFall <= 0)
        {
            barra.value -= velocidadBajada*Time.deltaTime;
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

        if (arriba)
        {
            zonaBuena.rectTransform.pivot =new Vector2(0.5f, Mathf.Clamp(zonaBuena.rectTransform.pivot.y + ((velMovimiento / 2) * Time.deltaTime),0,1-(tamanioZonaBuena/2)));
        }
        else
        {
            zonaBuena.rectTransform.pivot = new Vector2(0.5f, Mathf.Clamp(zonaBuena.rectTransform.pivot.y - ((velMovimiento / 2) * Time.deltaTime), 0, 1 - (tamanioZonaBuena / 2)));
        }
        if ((zonaBuena.rectTransform.pivot.y > destino-0.1f && arriba) || (zonaBuena.rectTransform.pivot.y < destino + 0.1f&& !arriba))
        {
            destino= Random.Range(0f, 1f- (tamanioZonaBuena / 2));
            if (destino < zonaBuena.rectTransform.pivot.y)
            {
                arriba = false;
            }
            else
            {
                arriba = true;
            }
        }
        if(barra.value>= zonaBuena.rectTransform.pivot.y-(tamanioZonaBuena / 2) && barra.value <= zonaBuena.rectTransform.pivot.y + (tamanioZonaBuena / 2))
        {
            timerToWin += Time.deltaTime;
            gasofa.fillAmount = timerToWin / timeToWin;
            zonaBuena.color = rightColor;
            if (sonidoDeLlenado.isPlaying == false)
            {
                sonidoDeLlenado.Play();
            }
        }
        else
        {
            zonaBuena.color = wrongColor;
            if (sonidoDeLlenado.isPlaying == true)
            {
                sonidoDeLlenado.Pause();
            }
        }
        if (timerToWin >= timeToWin)
        {
            WinGame();
        }
        
    }
    void WinGame()
    {
        sonidoFinal.Play();
        minigame.Finished();
    }
}
