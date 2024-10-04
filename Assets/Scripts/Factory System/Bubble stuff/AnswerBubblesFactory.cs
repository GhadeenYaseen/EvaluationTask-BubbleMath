using UnityEngine;

public class AnswerBubblesFactory : Factory
{
    [HideInInspector] public int FirstNumber;
    [HideInInspector] public int SecondNumber;

    [SerializeField] private GameObject _currentBubbleProduct;

    public override IProduct GetProduct(Transform position)
    {
        FirstNumber = MathProblemFactory._mathProblemFactoryInstance.FirstNumber;
        SecondNumber = MathProblemFactory._mathProblemFactoryInstance.SecondNumber;

        GameObject instance = Instantiate(_currentBubbleProduct, position.position, Quaternion.identity);
        IProduct newProduct = instance.GetComponent<IProduct>();
        newProduct.GetNumbers(FirstNumber, SecondNumber);

        newProduct.DisplayProduct();
        return newProduct;
    }
}
