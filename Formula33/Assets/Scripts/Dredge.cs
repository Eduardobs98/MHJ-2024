using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dredge : MonoBehaviour
{
    public GameObject circulo;
    public float velocidadRotacion;
    public bolitaMovil bmovil;
    public int maxpuntuacion;
    public float speedMultiplier;
    int puntuacion;
    public miniGame minigame;
    bool secondPlayer;
    // Start is called before the first frame update
    void Start()
    {
        puntuacion = 0;
        secondPlayer = minigame.controlador.secondPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        circulo.transform.rotation *= Quaternion.Euler(0, 0, -velocidadRotacion * Time.deltaTime);
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (bmovil.dentro == true)
                {
                    puntuacion++;
                    velocidadRotacion *= speedMultiplier;
                    bmovil.quitarChoclo();
                    if (puntuacion >= maxpuntuacion)
                    {
                        WinGame();
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (bmovil.dentro == true)
                {
                    puntuacion++;
                    velocidadRotacion *= speedMultiplier;
                    bmovil.quitarChoclo();
                    if (puntuacion >= maxpuntuacion)
                    {
                        WinGame();
                    }
                }
            }
        }
        
    }
    void WinGame()
    {
        minigame.Finished();
    }
}
