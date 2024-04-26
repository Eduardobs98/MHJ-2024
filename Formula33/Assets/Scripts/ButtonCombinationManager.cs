using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonCombinationManager : MonoBehaviour
{

    
    [SerializeField]
    private List<ButtonOfButtonCombination> buttonTypes;

    private ButtonOfButtonCombination nextButton;
    [SerializeField]
    private List<ButtonOfButtonCombination> currentButtonCombination;

    private int nextNumberInCombination = 0;

    private ButtonOfButtonCombination currentButton;
    private int currentButtonType = 0;
    private int currentButtonIndex = 0;

    public int completedCombinations = 0;
    public int maxCombinations = 4;

    private void Awake()
    {
        for (int i = 0; i < currentButtonCombination.Count; i++)
        {
            currentButtonCombination[i].enabled = false;
        }
        GenerateCombination();

    }

    // Start is called before the first frame update
    void Start()
    {
        completedCombinations = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentButtonType == 0)
            {
                currentButton.PressButton();
                NextButton();
            }
            else
                ResetCombination();

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentButtonType == 1)
            {
                currentButton.PressButton();
                NextButton();
            }
            else
                ResetCombination();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentButtonType == 2)
            {
                currentButton.PressButton();
                NextButton();
            }
            else
                ResetCombination();
        }

        if (Input.GetKeyDown(KeyCode.R))
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


    public void GenerateCombination ()
    {

        for (int i = 0; i < currentButtonCombination.Count; i++)
        {
            
            nextNumberInCombination = Random.Range(0, 4);
            currentButtonCombination[i] = Instantiate<ButtonOfButtonCombination>(buttonTypes[nextNumberInCombination], currentButtonCombination[i].transform);
            currentButtonCombination[i].enabled = true;
        }

        currentButton = currentButtonCombination[0];
        currentButtonIndex = 0;
        currentButtonType = currentButton.GetButtonType();
        
    }

    public void NextButton()
    {
        if(currentButtonIndex < currentButtonCombination.Count-1)
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
        completedCombinations++;
        if(completedCombinations >= maxCombinations)
        {
            Debug.Log("You Win");
        } else
        {
            GenerateCombination();
        }
    }

    public void ResetCombination()
    {
        for (int i = 0; i < currentButtonIndex; i++)
        {
            currentButtonCombination[i].ResetButton();
        }
        currentButton = currentButtonCombination[0];
        currentButtonIndex = 0;
        currentButtonType = currentButton.GetButtonType();
    }

}
