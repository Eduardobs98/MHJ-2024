using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class miniGameController : MonoBehaviour
{
    public List<miniGame> minigames;
    public Transform miniGameSpawn;
    miniGame currentMinigame;
    int indice = 0;
    public bool secondPlayer;
    public int adaptableDifficulty = 0; //0 = easy, 1 = medium, 2 = difficult

    public int adaptableDifficultyThresholdMedium;
    public int adaptableDifficultyThresholdHard;


    public TMP_Text puntuacion;
    int puntos;
    // Start is called before the first frame update
    private void Awake()
    {
        indice = Random.Range(0, minigames.Count);
        Debug.Log(indice);
        InstantiateMiniGame();
        puntos = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextMiniGame()
    {
        int indiceAux = indice;

        do
            indice = Random.Range(0, minigames.Count);
        while (indiceAux == indice);
        
        if(puntos >= adaptableDifficultyThresholdHard)
        {
            adaptableDifficulty = 2;

        }
        else if(puntos >= adaptableDifficultyThresholdMedium)
        {
            adaptableDifficulty = 1;

        }

        InstantiateMiniGame();
    }
    void InstantiateMiniGame()
    {
        currentMinigame = Instantiate<miniGame>(minigames[indice], miniGameSpawn);
        currentMinigame.controlador = this;
    }
    public void EndMinigame()
    {
        Destroy(currentMinigame.gameObject);
        puntos++;
        puntuacion.text = puntos.ToString();
        NextMiniGame();
        
    }
}
