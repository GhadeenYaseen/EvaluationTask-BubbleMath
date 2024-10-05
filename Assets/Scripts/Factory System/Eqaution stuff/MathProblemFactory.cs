using UnityEngine;

/*
    generate two numbers randomnly, call func from product to send them, product then displays equation
*/

public class MathProblemFactory : Factory
{
    [HideInInspector] public static MathProblemFactory _mathProblemFactoryInstance {get; private set;}

    [HideInInspector] public int FirstNumber;
    [HideInInspector] public int SecondNumber;

    [SerializeField] private GameObject _currentProduct, _position;

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

    public override IProduct GetProduct()
    {
        GenerateEquation();

        GameObject instance = Instantiate(_currentProduct, _position.transform.position, Quaternion.identity);
        IProduct newProduct = instance.GetComponent<IProduct>();
        newProduct.GetNumbers(FirstNumber, SecondNumber);

        newProduct.DisplayProduct();
        return newProduct;
    }

    public void GenerateEquation()
    {
        FirstNumber = Mathf.FloorToInt(Random.Range(0f, 10f));
        SecondNumber = Mathf.FloorToInt(Random.Range(0f, 10f));
    }
}
