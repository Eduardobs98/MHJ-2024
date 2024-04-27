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
    public float timeBetweenNotes;
    float timerBetweenNotes;

    // Start is called before the first frame update
    void Start()
    {
        timerBetweenNotes = 0;
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
                    mirarTeclas(notas1[Random.Range(0,notas1.Count)]);
                }
                else
                {
                    mirarTeclas(notas2[Random.Range(0, notas2.Count)]);
                }
            }
        }
    }

    void cNote(Transform posicion)
    {
        GameObject teclita = Instantiate(tecla, posicion);
        teclita.transform.parent = null;
    }

    void mirarTeclas(Vector4 queTeclas)
    {
        if (queTeclas.x == 1)
        {
            cNote(nota1);
        }
        if (queTeclas.y == 1)
        {
            cNote(nota2);
        }
        if (queTeclas.z == 1)
        {
            cNote(nota3);
        }
        if (queTeclas.w == 1)
        {
            cNote(nota4);
        }
    }
}
