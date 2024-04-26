using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitar : MonoBehaviour
{
    public teclasPulsables tecla1;
    public teclasPulsables tecla2;
    public teclasPulsables tecla3;
    public teclasPulsables tecla4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(tecla1.hayNota == true)
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tecla3.hayNota == true)
            {
                Destroy(tecla3.nota);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (tecla4.hayNota == true)
            {
                Destroy(tecla4.nota);
            }
        }
    }
}
