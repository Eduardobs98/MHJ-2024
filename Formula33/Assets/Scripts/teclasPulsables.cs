using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teclasPulsables : MonoBehaviour
{
    public bool hayNota;
    public GameObject nota;
    // Start is called before the first frame update
    void Start()
    {
        hayNota = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            hayNota = true;
            nota = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            hayNota = false;
            nota = null;
        }
    }
}
