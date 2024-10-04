using TMPro;
using UnityEngine;

public class AdditionBubbleProduct : MonoBehaviour, IProduct
{
    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [HideInInspector] private int twoNumbersResult;
    [SerializeField] private TextMeshProUGUI textUI;

    public TextMeshProUGUI TextUI { get => textUI; set => textUI = value; }

    public void DisplayProduct()
    {
        textUI.text = " ";
        Debug.Log("Addition bubble" + firstNumber + " " + secondNumber);

        twoNumbersResult = firstNumber + secondNumber;
        BubbleButton.bubbleButtonInstance.GetCorrectAnswer(twoNumbersResult);

        textUI.text = twoNumbersResult.ToString();
    }

    public void GetNumbers(int num1, int num2)
    {
        //also send to bubbles observer system to create correct answer bubble
        firstNumber = num1;
        secondNumber = num2;
    }
}
