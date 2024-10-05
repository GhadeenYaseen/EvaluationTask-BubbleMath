
using TMPro;
using UnityEngine;

public interface IProduct 
{
    public TextMeshPro TextUI {get; set;}

    public void DisplayProduct();
    public void GetNumbers(int num1 =0, int num2=0);
}
