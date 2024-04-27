using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNote : MonoBehaviour
{
    public Transform nota1;
    public Transform nota2;
    public Transform nota3;
    public Transform nota4;
    public GameObject tecla;
    public List<Vector4> notas1;
    public List<Vector4> notas2;
    public List<GameObject> teclasP1;
    public List<GameObject> teclasP2;
    public float timeBetweenNotes;
    float timerBetweenNotes;
    public miniGame minigame;
    bool secondPlayer;

    // Start is called before the first frame update
    void Start()
    {
        timerBetweenNotes = 0;
        secondPlayer = minigame.controlador.secondPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        timerBetweenNotes -= Time.deltaTime;
        if (timerBetweenNotes <= 0)
        {
            timerBetweenNotes = timeBetweenNotes;
            if(notas1.Count >=1 && notas2.Count >=1)
            {
                int cual;
                cual = Random.Range(1, 3);
                if (!secondPlayer)
                {
                    if (cual == 1)
                    {
                        mirarTeclas(notas1[Random.Range(0, notas1.Count)],secondPlayer);
                    }
                    else
                    {
                        mirarTeclas(notas2[Random.Range(0, notas2.Count)],secondPlayer);
                    }
                }
                else
                {
                    if (cual == 1)
                    {
                        mirarTeclas(notas1[Random.Range(0, notas1.Count)], secondPlayer);
                    }
                    else
                    {
                        mirarTeclas(notas2[Random.Range(0, notas2.Count)], secondPlayer);
                    }
                }
                
            }
        }
    }

    void cNote(Transform posicion,GameObject tecla)
    {
        GameObject teclita = Instantiate(tecla, posicion);
        teclita.transform.parent = null;
    }

    void mirarTeclas(Vector4 queTeclas,bool player)
    {
        if (!player)
        {
            if (queTeclas.x == 1)
            {
                cNote(nota1,teclasP1[0]);
            }
            if (queTeclas.y == 1)
            {
                cNote(nota2, teclasP1[1]);
            }
            if (queTeclas.z == 1)
            {
                cNote(nota3, teclasP1[2]);
            }
            if (queTeclas.w == 1)
            {
                cNote(nota4, teclasP1[3]);
            }
        }
        else
        {
            if (queTeclas.x == 1)
            {
                cNote(nota1, teclasP2[0]);
            }
            if (queTeclas.y == 1)
            {
                cNote(nota2, teclasP2[1]);
            }
            if (queTeclas.z == 1)
            {
                cNote(nota3, teclasP2[2]);
            }
            if (queTeclas.w == 1)
            {
                cNote(nota4, teclasP2[3]);
            }
        }

    }
}
