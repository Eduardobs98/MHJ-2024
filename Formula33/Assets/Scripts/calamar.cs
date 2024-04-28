using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calamar : MonoBehaviour
{
    public Image tinta;
    public bool secondPlayer;
    public float tintaTime;
    float tintaTimer;
    public Color colorNegro;
    public Color colorTransparente;
    public float velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        tinta.color = colorTransparente;
        tintaTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(tintaTimer >=0)
        {
            tintaTimer-= Time.deltaTime;
        }
       
        if(!secondPlayer) 
        {
            if(Input.GetKeyUp(KeyCode.P)) 
            {
                //tinta.gameObject.SetActive(true);
                tinta.color = colorNegro;
                tintaTimer = tintaTime;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                //tinta.gameObject.SetActive(true);
                tinta.color = colorNegro;
                tintaTimer = tintaTime;
            }
        }
        if (tintaTimer < tintaTime * 0.5f && tintaTimer > tintaTime * 0.1f)
        {
            //tinta.color = Color.Lerp(colorNegro, colorTransparente, velocidad*Time.deltaTime);
            tinta.color = new Vector4(tinta.color.r, tinta.color.g, tinta.color.b, Mathf.Lerp(1,0, velocidad * Time.fixedDeltaTime));
        }
        if(tintaTimer < tintaTime * 0.1f)
        {
            tinta.color = new Vector4(tinta.color.r, tinta.color.g, tinta.color.b, 0);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
