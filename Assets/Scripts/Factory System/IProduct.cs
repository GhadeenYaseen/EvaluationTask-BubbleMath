
using TMPro;

public interface IProduct 
{
    public TextMeshProUGUI TextUI {get; set;}

    public void DisplayProduct();
    public void GetNumbers(int num1 =0, int num2=0);
}
