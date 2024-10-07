using TMPro;
using UnityEngine;

public class MultiplicationProduct : MonoBehaviour, IProduct
{
    [HideInInspector] public static MultiplicationProduct _multiplyProductInstance {get; private set;}

    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [SerializeField] private TextMeshPro textUI;

    public TextMeshPro TextUI { get => textUI; set => textUI = value; }

    private void Awake() 
    {
        if(_multiplyProductInstance != null )
        {
            Destroy(_multiplyProductInstance.gameObject);
        }
        
        _multiplyProductInstance = this;
    }

    public void DisplayProduct()
    {
        textUI.text = " ";
        textUI.text = firstNumber + " * " + secondNumber;
    }

    public void GetNumbers(int num1, int num2)
    {
        firstNumber = num1;
        secondNumber = num2;
    }
}
