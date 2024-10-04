using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtractionBubbleProduct : MonoBehaviour, IProduct
{
    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [HideInInspector] private int twoNumbersResult;
    [SerializeField] private TextMeshProUGUI textUI;

    public int FirstNumber { get => firstNumber; set => firstNumber = value; }
    public int SecondNumber { get => secondNumber; set => secondNumber = value; }
    public int TwoNumbersResult { get => twoNumbersResult; set => twoNumbersResult = value; }
    public TextMeshProUGUI TextUI { get => textUI; set => textUI = value; }

    public void DisplayProduct()
    {
        textUI.text = " ";
        Debug.Log("subtraction bubble" + firstNumber + " " + secondNumber);

        twoNumbersResult = firstNumber - secondNumber;
        textUI.text = twoNumbersResult.ToString();
    }

    public void GetNumbers(int num1, int num2)
    {
        //also send to bubbles observer system to create correct answer bubble
        firstNumber = num1;
        secondNumber = num2;
    }
}
