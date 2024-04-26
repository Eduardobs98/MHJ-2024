using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOfButtonCombination : MonoBehaviour
{


    [SerializeField]
    private GameObject buttonToPress;
    [SerializeField]
    private GameObject pressedButton;
    [SerializeField]
    private int buttonType;

    private void Awake()
    {
        pressedButton.SetActive(false);
    }

    public void PressButton()
    {
        buttonToPress.SetActive(false);
        pressedButton.SetActive(true);
    }

    public void ResetButton()
    {
        buttonToPress.SetActive(true);
        pressedButton.SetActive(false);
    }

    public int GetButtonType()
    {
        return buttonType;
    }

}
