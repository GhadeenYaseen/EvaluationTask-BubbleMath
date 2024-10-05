using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtractionProduct : MonoBehaviour, IProduct
{
    [HideInInspector] public static SubtractionProduct _subtractionProductInstance {get; private set;}

    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [HideInInspector] private int twoNumbersResult;
    [SerializeField] private TextMeshPro textUI;

    public int FirstNumber { get => firstNumber; set => firstNumber = value; }
    public int SecondNumber { get => secondNumber; set => secondNumber = value; }
    public int TwoNumbersResult { get => twoNumbersResult; set => twoNumbersResult = value; }
    public TextMeshPro TextUI { get => textUI; set => textUI = value; }

    private void Awake() 
    {
        if(_subtractionProductInstance != null )
        {
            Debug.Log("instance destroyed");
            Destroy(_subtractionProductInstance.gameObject);
        }
            Debug.Log("instance is assigned");
            _subtractionProductInstance = this;
        
    }

    public void DisplayProduct()
    {
        textUI.text = " ";
        Debug.Log("subtraction product" + firstNumber + " " + secondNumber);
        textUI.text = firstNumber + " - " + secondNumber;
    }

    public void GetNumbers(int num1, int num2)
    {
        //also send to bubbles observer system to create correct answer bubble
        firstNumber = num1;
        secondNumber = num2;
    }
}
