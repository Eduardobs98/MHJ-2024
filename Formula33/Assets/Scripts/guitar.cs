using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guitar : MonoBehaviour
{
    public teclasPulsables tecla1;
    public teclasPulsables tecla2;
    public teclasPulsables tecla3;
    public teclasPulsables tecla4;
    public miniGame minigame;
    bool secondPlayer;
    int numNotas;
    private int maxNotas;
    public int adaptableDifficulty;

    public int maxNotasEasy;
    public int maxNotasMedium;
    public int maxNotasLarge;

    public AudioSource audioSource;
    public List<AudioClip> beepSounds;
    public List<AudioClip> failBeepSounds;


    // Start is called before the first frame update
    void Start()
    {
        numNotas = 0;
        secondPlayer = minigame.controlador.secondPlayer;
        adaptableDifficulty = minigame.controlador.adaptableDifficulty;

        if (adaptableDifficulty == 0)
        {
            maxNotas = maxNotasEasy;
        }
        else if (adaptableDifficulty == 1)
        {
            maxNotas = maxNotasMedium;
        }
        else if (adaptableDifficulty >= 2)
        {
            maxNotas = maxNotasLarge;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (tecla1.hayNota == true)
                {
                    Destroy(tecla1.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla2.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla3.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla4.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (tecla1.hayNota == true)
                {
                    Destroy(tecla1.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (tecla2.hayNota == true)
                {
                    Destroy(tecla2.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (tecla3.hayNota == true)
                {
                    Destroy(tecla3.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (tecla4.hayNota == true)
                {
                    Destroy(tecla4.nota);
                    numNotas++;
                    playBeepSound();
                }
                else
                {
                    playBeepFailSound();
                }
            }
        }
        if (numNotas >= maxNotas)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        minigame.Finished();
    }

    public void playBeepSound()
    {
        int i = Random.Range(0, beepSounds.Count);
        audioSource.clip = beepSounds[i];
        audioSource.Play();
    }

    public void playBeepFailSound()
    {
        int i = Random.Range(0, failBeepSounds.Count);
        audioSource.clip = failBeepSounds[i];
        audioSource.Play();
    }
}
