using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volante : MonoBehaviour
{
    public float velocidadGiro;
    public GameObject circulo;
    public GameObject zona1;
    public GameObject zona2;
    public GameObject zona3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        circulo.transform.rotation *= Quaternion.Euler(0, 0, velocidadGiro * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (circulo.transform.rotation.eulerAngles.z >= zona1.transform.rotation.eulerAngles.z && circulo.transform.rotation.eulerAngles.z + (circulo.GetComponent<Image>().fillAmount * 360) <= zona1.transform.rotation.eulerAngles.z + (zona1.GetComponent<Image>().fillAmount * 360))
            {
                Debug.Log("FINO");
                Debug.Log(circulo.transform.rotation.eulerAngles.z);
                Debug.Log(zona1.transform.rotation.eulerAngles.z);
                Debug.Log(circulo.transform.rotation.eulerAngles.z + (circulo.GetComponent<Image>().fillAmount * 360));
                Debug.Log(zona1.transform.rotation.eulerAngles.z + (zona1.GetComponent<Image>().fillAmount * 360));
            }
        }
        
    }
}
