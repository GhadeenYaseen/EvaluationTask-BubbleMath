using UnityEngine;

public class AnswerBubblesFactory : Factory
{
    [HideInInspector] public int FirstNumber;
    [HideInInspector] public int SecondNumber;

    [SerializeField] private GameObject _currentBubbleProduct;

    public override IProduct GetProduct()
    {
        FirstNumber = MathProblemFactory._mathProblemFactoryInstance.FirstNumber;
        SecondNumber = MathProblemFactory._mathProblemFactoryInstance.SecondNumber;

        Vector3 currentPos = RandomPosition();

        GameObject instance = Instantiate(_currentBubbleProduct, currentPos, Quaternion.identity);
        IProduct newProduct = instance.GetComponent<IProduct>();

        newProduct.GetNumbers(FirstNumber, SecondNumber);
        newProduct.DisplayProduct();

        return newProduct;
    }

    private Vector3 RandomPosition()
    {
        float x = Random.Range(0.47f,-2.95f);
        float y = -5.97f;

        Vector3 vec3 = new Vector3(x,y,-0.05f);
        
        return vec3;
    }
}
