using TMPro;
using UnityEngine;

public class RandomBubbleProduct : MonoBehaviour, IProduct
{
    private int randomBubbleNumber;

    [SerializeField] private TextMeshProUGUI textUI;
    public TextMeshProUGUI TextUI { get => textUI; set => textUI = value; }

    public void DisplayProduct()
    {
        TextUI.text = " ";
        Debug.Log("random bubble" + randomBubbleNumber);

        TextUI.text = randomBubbleNumber.ToString();
    }

    public void GetNumbers(int num1 = 0, int num2 = 0)
    {
        randomBubbleNumber = num1;
    }
}
