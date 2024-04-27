using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bolitaMovil : MonoBehaviour
{
    public bool dentro;
    Collider2D choclo;
    // Start is called before the first frame update
    void Start()
    {
        dentro = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dredge")
        {
            dentro = true;
            choclo = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dredge")
        {
            dentro = false;
        }
    }
    public void quitarChoclo()
    {
        choclo.enabled = false;
        choclo.gameObject.GetComponentInParent<Image>().color = Color.cyan;
    }
}
