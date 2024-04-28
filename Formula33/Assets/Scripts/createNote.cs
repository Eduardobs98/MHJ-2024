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
    public List<GameObject> teclas;
    private float timeBetweenNotes;
    float timerBetweenNotes;
    public miniGame minigame;
    public int adaptableDifficulty;

    public float timeBetweenNotesEasy;
    public float timeBetweenNotesMedium;
    public float timeBetweenNotesHard;


    // Start is called before the first frame update
    void Start()
    {
        adaptableDifficulty = minigame.controlador.adaptableDifficulty;
        timerBetweenNotes = 0;

        if (adaptableDifficulty == 0)
        {
            timeBetweenNotes = timeBetweenNotesEasy;
        }
        else if (adaptableDifficulty == 1)
        {
            timeBetweenNotes = timeBetweenNotesMedium;
        }
        else if (adaptableDifficulty >= 2)
        {
            timeBetweenNotes = timeBetweenNotesHard;
        }
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
                    if (cual == 1)
                    {
                        mirarTeclas(notas1[Random.Range(0, notas1.Count)]);
                    }
                    else
                    {
                        mirarTeclas(notas2[Random.Range(0, notas2.Count)]);
                    }
                
            }
        }
    }

    void cNote(Transform posicion,GameObject tecla)
    {
        GameObject teclita = Instantiate(tecla, posicion);
        //teclita.transform.parent = null;
    }

    void mirarTeclas(Vector4 queTeclas)
    {
            if (queTeclas.x == 1)
            {
                cNote(nota1,teclas[0]);
            }
            if (queTeclas.y == 1)
            {
                cNote(nota2, teclas[1]);
            }
            if (queTeclas.z == 1)
            {
                cNote(nota3, teclas[2]);
            }
            if (queTeclas.w == 1)
            {
                cNote(nota4, teclas[3]);
            }
    }
}
