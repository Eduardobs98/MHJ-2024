using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class miniGameController : MonoBehaviour
{
    public List<miniGame> minigames;
    public Transform miniGameSpawn;
    miniGame currentMinigame;
    int indice = -1;
    int indiceNoRepeat1 = -1;
    int indiceNoRepeat2 = -1;
    public bool secondPlayer;
    public int adaptableDifficulty = 0; //0 = easy, 1 = medium, 2 = difficult

    public int adaptableDifficultyThresholdMedium;
    public int adaptableDifficultyThresholdHard;
    public GameObject coche;
    GameObject currentCoche;
    public Transform salida;
    public Transform aparcamiento;
    public float timeEntreEsperas;
    float timerEntreEsperas;
    public float baseTimerEntreEsperas = 0.5f;
    bool minigameEnded = false;

    public TMP_Text puntuacion;
    public int puntos;
    // Start is called before the first frame update
    private void Awake()
    {
        indice = Random.Range(0, minigames.Count);
        Debug.Log(indice);
        timerEntreEsperas = timeEntreEsperas;
        InstantiateMiniGame();
        puntos = 0;
    }
    void Start()
    {
        puntuacion.text = puntos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!minigameEnded)
            return;
        timerEntreEsperas -= Time.deltaTime;
        if (timerEntreEsperas > 0)
            return;

        if (indiceNoRepeat1 >= 0)
            indiceNoRepeat2 = indiceNoRepeat1;

        indiceNoRepeat1 = indice;

        do
            indice = Random.Range(0, minigames.Count);
        while (indiceNoRepeat1 == indice || indiceNoRepeat2 == indice);

        if (puntos >= adaptableDifficultyThresholdHard)
        {
            adaptableDifficulty = 2;

        }
        else if (puntos >= adaptableDifficultyThresholdMedium)
        {
            adaptableDifficulty = 1;

        }

        InstantiateMiniGame();

    }
    void NextMiniGame()
    {
        minigameEnded = true;
        timerEntreEsperas = baseTimerEntreEsperas;        
    }
    void InstantiateMiniGame()
    {
        minigameEnded = false;
        currentMinigame = Instantiate<miniGame>(minigames[indice], miniGameSpawn);
        currentMinigame.controlador = this;
        currentCoche = Instantiate(coche, salida);
        currentCoche.GetComponent<cocheRojo>().aparcamiento = aparcamiento;
    }
    public void EndMinigame()
    {
        Destroy(currentMinigame.gameObject);
        puntos++;
        puntuacion.text = puntos.ToString();
        currentCoche.GetComponent<cocheRojo>().siga = true;
        NextMiniGame();
    }
}
