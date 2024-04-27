using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pesca : MonoBehaviour
{
    public Slider barra;
    public float velocidad;
    public float subida;
    public float timeToFall;
    float timerToFall;
    public RawImage zonaBuena;
    public float tamanioZonaBuena;
    float destino;
    public float velMovimiento;
    bool arriba;
    public miniGame minigame;
    bool secondPlayer;

    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0;
        timerToFall = timeToFall;
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
            barra.value = Mathf.Lerp(barra.value, 0, (velocidad )*Time.deltaTime);
        }
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                barra.value += subida / 100;
                timerToFall = timeToFall;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                barra.value += subida / 100;
                timerToFall = timeToFall;
            }
        }
        
        zonaBuena.rectTransform.pivot = new Vector2(0.5f, Mathf.Lerp(zonaBuena.rectTransform.pivot.y, destino, (velMovimiento) * Time.deltaTime));
        if ((zonaBuena.rectTransform.pivot.y > destino-0.1f && arriba) || (zonaBuena.rectTransform.pivot.y < destino + 0.1f&& !arriba))
        {
            destino= Random.Range(0f, 1f);
            if (destino < zonaBuena.rectTransform.pivot.y)
            {
                arriba = false;
            }
            else
            {
                arriba = true;
            }
            Debug.Log(destino);
        }
    }
}
