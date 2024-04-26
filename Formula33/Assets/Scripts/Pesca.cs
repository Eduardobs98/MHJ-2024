using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pesca : MonoBehaviour
{
    public Slider barra;
    public float velocidad;
    public float subida;
    public float timeToFall;
    float timerToFall;
    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0.5f;
        timerToFall = timeToFall;
    }

    // Update is called once per frame
    void Update()
    {
        timerToFall -= Time.deltaTime;
        if(timerToFall <= 0)
        {
            barra.value = Mathf.Lerp(barra.value, 0, velocidad / 1000);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            barra.value += subida / 100;
            timerToFall = timeToFall;
        }
    }
}
