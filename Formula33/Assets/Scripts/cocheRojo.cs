using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocheRojo : MonoBehaviour
{
    public float velocidadCoche;
    public Transform aparcamiento;
    bool parado;
    public Animator animadorCoche;
    // Start is called before the first frame update
    void Start()
    {
        parado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!parado)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, aparcamiento.position, velocidadCoche * Time.deltaTime);

        }
        if (gameObject.transform.position.y > aparcamiento.position.y-0.1 && !parado)
        {
            parado = true;
            Debug.Log("Pinga");
            animadorCoche.SetTrigger("Parar");
        }
        
    }
}
