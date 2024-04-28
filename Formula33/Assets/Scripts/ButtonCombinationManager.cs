using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCombinationManager : MonoBehaviour
{

    
    [SerializeField]
    private List<ButtonOfButtonCombination> buttonTypes;

    //[SerializeField]
    //private List<ButtonOfButtonCombination> buttonTypesP2;

    [SerializeField]
    private List<ButtonOfButtonCombination> currentButtonCombination;

    [SerializeField]
    private List<GameObject> positions;

    public List<GameObject> positionsEasy;
    public List<GameObject> positionsMedium;
    public List<GameObject> positionsHard;


    [SerializeField]
    private int numberOfButtons = 4;

    private int nextNumberInCombination = 0;

    private ButtonOfButtonCombination currentButton;
    private int currentButtonType = 0;
    private int currentButtonIndex = 0;

    public int completedCombinations = 0;
    private int maxCombinations = 3;

    public int maxCombinationsEasy = 3;
    public int maxCombinationsMedum = 4;
    public int maxCombinationsHard = 5;

    public miniGame minigame;
    bool secondPlayer;
    public int adaptableDifficulty = 0;


    public AudioSource audioSourceTaladro;
    public List<AudioClip> clipsAudio;

    // Start is called before the first frame update
    void Start()
    {
        secondPlayer = minigame.controlador.secondPlayer;
        /*
        if (secondPlayer)
            buttonTypes = buttonTypesP2;
        */
        adaptableDifficulty = minigame.controlador.adaptableDifficulty;

        if(adaptableDifficulty == 0)
        {
            maxCombinations = maxCombinationsEasy;
            positions = positionsEasy;
        } else if (adaptableDifficulty == 1)
        {
            maxCombinations = maxCombinationsMedum;
            positions = positionsMedium;
        } else if (adaptableDifficulty >= 2)
        {
            maxCombinations = maxCombinationsHard;
            positions = positionsHard;
        }
        numberOfButtons = positions.Count;
        completedCombinations = 0;
        GenerateCombination();
    }

    // Update is called once per frame
    void Update()
    {

        if(!secondPlayer)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (currentButtonType == 0)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (currentButtonType == 1)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }

            else if(Input.GetKeyDown(KeyCode.S))
            {
                if (currentButtonType == 2)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }

            else if(Input.GetKeyDown(KeyCode.D))
            {
                if (currentButtonType == 3)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (currentButtonType == 0)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();

            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentButtonType == 1)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }

            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (currentButtonType == 2)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }

            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentButtonType == 3)
                {
                    currentButton.PressButton();
                    NextButton();
                }
                else
                    ResetCombination();
            }
        }
       
    }


    public void GenerateCombination ()
    {
        DeleteOldCombination();
        for (int i = 0; i < numberOfButtons; i++)
        {
            
            nextNumberInCombination = Random.Range(0, 4);
            currentButtonCombination.Add(Instantiate<ButtonOfButtonCombination>(buttonTypes[nextNumberInCombination], positions[i].transform));
            //currentButtonCombination[i] = Instantiate<ButtonOfButtonCombination>(buttonTypes[nextNumberInCombination], currentButtonCombination[i].transform);
            currentButtonCombination[i].enabled = true;
        }

        currentButton = currentButtonCombination[0];
        currentButtonIndex = 0;
        currentButtonType = currentButton.GetButtonType();
        
    }

    public void DeleteOldCombination()
    {
        for (int i = 0; i < currentButtonCombination.Count; i++)
        {
            Destroy(currentButtonCombination[i].gameObject);
        }
        currentButtonCombination.Clear();

    }

    public void NextButton()
    {
        PlayDrillSound();
        if (currentButtonIndex < currentButtonCombination.Count-1)
        {
            currentButtonIndex++;
            currentButton = currentButtonCombination[currentButtonIndex];
            currentButtonType = currentButton.GetButtonType();
        }
        else
        {
            CompleteCombination();
            
        }
           
        
    }

    public void CompleteCombination()
    {
        //PlayDrillSound();

        completedCombinations++;
        if (completedCombinations >= maxCombinations)
        {
            minigame.Finished();
        } else
        {
            GenerateCombination();
        }
    }

    public void ResetCombination()
    {

        GenerateCombination();
        /*
        for (int i = 0; i < currentButtonCombination.Count; i++)
        {
            currentButtonCombination[i].ResetButton();
        }
        currentButton = currentButtonCombination[0];
        currentButtonIndex = 0;
        currentButtonType = currentButton.GetButtonType();
        */
    }

    public void PlayDrillSound()
    {
        int i = Random.Range(0, clipsAudio.Count);
        audioSourceTaladro.clip = clipsAudio[i];
        audioSourceTaladro.Play();
    }

}
