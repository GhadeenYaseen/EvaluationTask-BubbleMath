using TMPro;
using UnityEngine;

public class AdditionProduct : MonoBehaviour, IProduct
{
    [HideInInspector] public static AdditionProduct _additionProductInstance {get; private set;}

    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [SerializeField] private TextMeshProUGUI textUI;

    public TextMeshProUGUI TextUI { get => textUI; set => textUI = value; }

    private void Awake() 
    {
        if(_additionProductInstance != null )
        {
            Debug.Log("instance destroyed");
            Destroy(_additionProductInstance.gameObject);
        }
            Debug.Log("instance is assigned");
            _additionProductInstance = this;
        
    }

    public void DisplayProduct()
    {
        textUI.text = " ";
        Debug.Log("Addition product" + firstNumber + " " + secondNumber);
        textUI.text = firstNumber + " + " + secondNumber;
    }

    public void GetNumbers(int num1, int num2)
    {
        //also send to bubbles observer system to create correct answer bubble
        firstNumber = num1;
        secondNumber = num2;
    }
}
