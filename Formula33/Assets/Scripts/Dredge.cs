using System.Collections.Generic;
using UnityEngine;

public class Dredge : MonoBehaviour
{
    public GameObject circulo;
    public bolitaMovil bmovil;
    public int maxpuntuacion;
    int puntuacion;
    public miniGame minigame;
    bool secondPlayer;
    // Start is called before the first frame update
    public GameObject circulo1;
    public GameObject circulo2;
    public GameObject circulo3;

    private Vector3 game;
    public List<Vector3> preSets;

    private float velocidadRotacion;
    private float speedMultiplier;

    public float velocidadRotacionEasy;
    public float speedMultiplierEasy;

    public float velocidadRotacionMedium;
    public float speedMultiplierMedium;

    public float velocidadRotacionHard;
    public float speedMultiplierHard;

    public int adaptableDifficulty = 0;

    public AudioSource audioSource;
    public List<AudioClip> dredgeSounds;
    public List<AudioClip> dredgeFailSounds;
    public Animator animador;

    void Start()
    {
        puntuacion = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        adaptableDifficulty = minigame.controlador.adaptableDifficulty;
        game = preSets[Random.Range(0, preSets.Count)];

        circulo1.transform.rotation = Quaternion.Euler(0, 0, game.x);
        circulo2.transform.rotation = Quaternion.Euler(0, 0, game.y);
        circulo3.transform.rotation = Quaternion.Euler(0, 0, game.z);

        if (adaptableDifficulty == 0)
        {
            velocidadRotacion = velocidadRotacionEasy;
            speedMultiplier = speedMultiplierEasy;
        }
        else if (adaptableDifficulty == 1)
        {
            velocidadRotacion = velocidadRotacionMedium;
            speedMultiplier = speedMultiplierMedium;
        }
        else if (adaptableDifficulty >= 2)
        {
            velocidadRotacion = velocidadRotacionHard;
            speedMultiplier = speedMultiplierHard;
        }


    }

    // Update is called once per frame
    void Update()
    {
        circulo.transform.rotation *= Quaternion.Euler(0, 0, -velocidadRotacion * Time.deltaTime);
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (bmovil.dentro == true)
                {
                    puntuacion++;
                    velocidadRotacion *= speedMultiplier;
                    bmovil.quitarChoclo();
                    animador.SetTrigger("acertado");
                    PlayDredgeSound();
                    if (puntuacion >= maxpuntuacion)
                    {
                        WinGame();
                    }
                } 
                else
                {
                    PlayDredgeFailSound();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (bmovil.dentro == true)
                {
                    puntuacion++;
                    velocidadRotacion *= speedMultiplier;
                    bmovil.quitarChoclo();
                    animador.SetTrigger("acertado");
                    PlayDredgeSound();
                    if (puntuacion >= maxpuntuacion)
                    {
                        WinGame();
                    }
                }
                else
                {
                    PlayDredgeFailSound();
                }
            }
        }

    }

    public void PlayDredgeSound()
    {
        int i = Random.Range(0, dredgeSounds.Count);
        audioSource.clip = dredgeSounds[i];
        audioSource.Play();
    }

    public void PlayDredgeFailSound()
    {
        int i = Random.Range(0, dredgeFailSounds.Count);
        audioSource.clip = dredgeFailSounds[i];
        audioSource.Play();
    }

    void WinGame()
    {
        minigame.Finished();
    }
}
