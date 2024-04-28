using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    public miniGameController player1Controller;
    public miniGameController player2Controller;

    public TMP_Text timerText;
    public TMP_Text P1WinPointsPlayer1;
    public TMP_Text P1WinPointsPlayer2;
    public TMP_Text P2WinPointsPlayer1;
    public TMP_Text P2WinPointsPlayer2;
    public TMP_Text DrawPointsPlayer1;
    public TMP_Text DrawPointsPlayer2;

    public float timer;

    public GameObject winnerPannel;
    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject Draw;


    public int puntosPlayer1 = 0;
    public int puntosPlayer2 = 0;

    public bool seAcabo = false;

    public AudioSource music;

    public AudioClip endMusic;

    // Start is called before the first frame update
    void Start()
    {
        winnerPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0.0f && !seAcabo)
        {
            seAcabo = true;
            winnerPannel.SetActive(true);
            puntosPlayer1 = player1Controller.puntos;
            puntosPlayer2 = player2Controller.puntos;
            WinMusic();

            if (puntosPlayer1 > puntosPlayer2)
            {
                P1Win.SetActive(true);
                P2Win.SetActive(false);
                Draw.SetActive(false);

                P1WinPointsPlayer1.text = puntosPlayer1.ToString();
                P1WinPointsPlayer2.text = puntosPlayer2.ToString();

            }
            else if (puntosPlayer2 > puntosPlayer1)
            {
                P1Win.SetActive(false);
                P2Win.SetActive(true);
                Draw.SetActive(false);

                P2WinPointsPlayer1.text = puntosPlayer1.ToString();
                P2WinPointsPlayer2.text = puntosPlayer2.ToString();
            }
            else
            {
                P1Win.SetActive(false);
                P2Win.SetActive(false);
                Draw.SetActive(true);

                DrawPointsPlayer1.text = puntosPlayer1.ToString();
                DrawPointsPlayer2.text = puntosPlayer2.ToString();
            }
        }

        if(seAcabo)
        {
            if(Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene("MainMenu");
            }
        }

        var ts = TimeSpan.FromSeconds(timer);
        timerText.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        if (timer < 10)
        {
            timerText.color= Color.red;
        }
    }

    public void WinMusic()
    {
        music.Stop();
        music.clip = endMusic;
        music.Play();
    }
}
