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
    public List<Vector4> notas;
    public float timeBetweenNotes;
    float timerBetweenNotes;

    // Start is called before the first frame update
    void Start()
    {
        timerBetweenNotes = timeBetweenNotes;
    }

    // Update is called once per frame
    void Update()
    {
        timerBetweenNotes -= Time.deltaTime;
        if (timerBetweenNotes <= 0)
        {
            Debug.Log("Saco tecla");
            timerBetweenNotes = timeBetweenNotes;
            if(notas.Count >=1)
            {
                mirarTeclas(notas[0]);
                notas.RemoveAt(0);
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
