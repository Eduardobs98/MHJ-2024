using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pesca : MonoBehaviour
{
    public Slider barra;
    public float velocidadBajada;
    public float velocidadSubida;
    public float timeToFall;
    float timerToFall;
    public RawImage zonaBuena;
    public float tamanioZonaBuena;
    float destino;
    public float velMovimiento;
    bool arriba;
    public miniGame minigame;
    bool secondPlayer;
    public float timeToWin;
    float timerToWin;

    // Start is called before the first frame update
    void Start()
    {
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
        }
        if (timerToWin >= timeToWin)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        Debug.Log("Acabe");
        minigame.Finished();
    }
}
