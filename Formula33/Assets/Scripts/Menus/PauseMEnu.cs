using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PauseMEnu : MonoBehaviour
{
    public GameObject barraDeVida;
    public GameObject menuDePausa;
    public GameObject main;
    public GameObject options;
    public Button resume;
    public Button back;
    public AudioMixer audioMixer;
    public Slider audioSlider;
    private float valor;
    

    // Start is called before the first frame update
    void Start()
    {
        barraDeVida.SetActive(true);
        menuDePausa.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        barraDeVida.SetActive(true);
        menuDePausa.SetActive(false);
    }
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
        audioMixer.GetFloat("Volume", out valor);
        audioSlider.value = valor;
        back.Select();
    }
    public void Back()
    {
        main.SetActive(true);
        options.SetActive(false);
        resume.Select();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    /*
    public void Pause(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (barraDeVida.activeSelf)
            {
                barraDeVida.SetActive(false);
                menuDePausa.SetActive(true);
                main.SetActive(true);
                options.SetActive(false);
                resume.Select();
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                barraDeVida.SetActive(true);
                menuDePausa.SetActive(false);
            }
        }
    }
    */
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volume", volumen);
    }
}
