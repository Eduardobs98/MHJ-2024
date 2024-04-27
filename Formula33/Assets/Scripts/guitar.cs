using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitar : MonoBehaviour
{
    public teclasPulsables tecla1;
    public teclasPulsables tecla2;
    public teclasPulsables tecla3;
    public teclasPulsables tecla4;
    public teclasPulsables tecla12;
    public teclasPulsables tecla22;
    public teclasPulsables tecla32;
    public teclasPulsables tecla42;
    public miniGame minigame;
    bool secondPlayer;
    int numNotas;
    public int maxNotas;

    // Start is called before the first frame update
    void Start()
    {
        numNotas = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        if (!secondPlayer)
        {
            tecla1.gameObject.SetActive(true);
            tecla2.gameObject.SetActive(true);
            tecla3.gameObject.SetActive(true);
            tecla4.gameObject.SetActive(true);
            tecla12.gameObject.SetActive(false);
            tecla22.gameObject.SetActive(false);
            tecla32.gameObject.SetActive(false);
            tecla42.gameObject.SetActive(false);
        }
        else
        {
            tecla1.gameObject.SetActive(false);
            tecla2.gameObject.SetActive(false);
            tecla3.gameObject.SetActive(false);
            tecla4.gameObject.SetActive(false);
            tecla12.gameObject.SetActive(true);
            tecla22.gameObject.SetActive(true);
            tecla32.gameObject.SetActive(true);
            tecla42.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (tecla1.hayNota == true)
                {
                    Destroy(tecla1.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla2.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla3.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla4.nota);
                    numNotas++;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (tecla1.hayNota == true)
                {
                    Destroy(tecla12.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla22.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla32.nota);
                    numNotas++;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla42.nota);
                    numNotas++;
                }
            }
        }
        if (numNotas >= maxNotas)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        minigame.Finished();
    }
}
