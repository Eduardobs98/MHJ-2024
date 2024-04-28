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
    public bool canUseOil;
    
    // Start is called before the first frame update
    void Start()
    {
        tinta.color = colorTransparente;
        tintaTimer = 0;
        canUseOil = true;
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
            if(Input.GetKeyUp(KeyCode.P)&&canUseOil) 
            {
                //tinta.gameObject.SetActive(true);
                tinta.color = colorNegro;
                tintaTimer = tintaTime;
                canUseOil= false;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Q)&&canUseOil)
            {
                //tinta.gameObject.SetActive(true);
                tinta.color = colorNegro;
                tintaTimer = tintaTime;
                canUseOil = false;
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
}
