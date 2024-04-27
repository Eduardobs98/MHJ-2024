using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitar : MonoBehaviour
{
    public teclasPulsables tecla1;
    public teclasPulsables tecla2;
    public teclasPulsables tecla3;
    public teclasPulsables tecla4;
    public miniGame minigame;
    bool secondPlayer;

    // Start is called before the first frame update
    void Start()
    {
        secondPlayer = minigame.controlador.secondPlayer;
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
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla2.nota);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla3.nota);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla4.nota);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (tecla1.hayNota == true)
                {
                    Destroy(tecla1.nota);
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla2.nota);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla3.nota);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla4.nota);
                }
            }
        }
        
    }
}
