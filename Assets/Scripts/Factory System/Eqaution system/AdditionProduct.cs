using TMPro;
using UnityEngine;

public class AdditionProduct : MonoBehaviour, IProduct
{
    [HideInInspector] public static AdditionProduct _additionProductInstance {get; private set;}

    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [SerializeField] private TextMeshPro textUI;

    public TextMeshPro TextUI { get => textUI; set => textUI = value; }

    private void Awake() 
    {
        if(_additionProductInstance != null )
        {
            Destroy(_additionProductInstance.gameObject);
        }
        
        _additionProductInstance = this;
    }

    public void DisplayProduct()
    {
        textUI.text = " ";
        textUI.text = firstNumber + " + " + secondNumber;
    }

    public void GetNumbers(int num1, int num2)
    {
        firstNumber = num1;
        secondNumber = num2;
    }
}
