using UnityEngine;

/*
    generate two numbers randomnly, call func from product to send them, product then displays equation
*/

public class MathProblemFactory : Factory
{
    [HideInInspector] public static MathProblemFactory _mathProblemFactoryInstance {get; private set;}

    [HideInInspector] public int FirstNumber;
    [HideInInspector] public int SecondNumber;

    [SerializeField] private GameObject _currentProduct;

    private void Awake() 
    {
        if(_mathProblemFactoryInstance != null && _mathProblemFactoryInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _mathProblemFactoryInstance = this;
        }
    }

    public override IProduct GetProduct(Transform position)
    {
        GenerateEquation();

        GameObject instance = Instantiate(_currentProduct, position.position, Quaternion.identity);
        IProduct newProduct = instance.GetComponent<IProduct>();
        newProduct.GetNumbers(FirstNumber, SecondNumber);

        newProduct.DisplayProduct();
        return newProduct;
    }

    public void GenerateEquation()
    {
        FirstNumber = Mathf.FloorToInt(Random.Range(0f, 10f));
        SecondNumber = Mathf.FloorToInt(Random.Range(0f, 10f));

        Debug.Log("generated numbers" + FirstNumber + " " + SecondNumber);
    }
}
