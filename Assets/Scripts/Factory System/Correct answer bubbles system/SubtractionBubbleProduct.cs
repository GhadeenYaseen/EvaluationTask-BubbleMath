using TMPro;
using UnityEngine;

public class SubtractionBubbleProduct : MonoBehaviour, IProduct
{
    [HideInInspector] private int firstNumber;
    [HideInInspector] private int secondNumber;
    [HideInInspector] private int twoNumbersResult;
    [SerializeField] private TextMeshPro textUI;

    public TextMeshPro TextUI { get => textUI; set => textUI = value; }

    public void DisplayProduct()
    {
        textUI.text = " ";
        Debug.Log("subtraction bubble" + firstNumber + " " + secondNumber);

        twoNumbersResult = firstNumber - secondNumber;
        ScoreMiddleMan.middleManInstance.GetCorrectAnswer(twoNumbersResult);

        textUI.text = twoNumbersResult.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Bubble Wall"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = SetPos();
            gameObject.SetActive(true);
        }   
    }

    public void GetNumbers(int num1, int num2)
    {
        firstNumber = num1;
        secondNumber = num2;
    }

    public Vector3 SetPos()
    {
        float x = Random.Range(0.9f,-3.5f);
        float y = -5.97f;

        Vector3 vec3 = new Vector3(x,y,-0.05f);
        
        return vec3;
    }
}
