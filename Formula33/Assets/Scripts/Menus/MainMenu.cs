using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Scene firstScene;
    public GameObject main;
    public GameObject options;
    public GameObject credits;
    public Button volumeSlider;
    public Button playButton;
    public Button back;
    public Slider audioSlider;
    public AudioMixer audioMixer;
    private float valor;
    public AudioSource click;
    public AudioSource hover;


    private void Start()
    {
        main.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
    }
    public void Play()
    {
        click.Play();
        SceneManager.LoadScene("MainScene");
    } 
    
    public void Options()
    {
        click.Play();
        main.SetActive(false);
        options.SetActive(true);
        audioMixer.GetFloat("Volume",out valor);
        audioSlider.value = valor;
    }

    public void Exit()
    {
        click.Play();
        Application.Quit();
    }
    public void Credits()
    {
        click.Play();
        main.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
    }
    public void Back()
    {
        click.Play();
        main.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
    }
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volume", volumen);
    }
}
