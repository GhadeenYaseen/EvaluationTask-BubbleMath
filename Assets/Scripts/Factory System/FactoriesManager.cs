using System.Collections.Generic;
using UnityEngine;

public class FactoriesManager : MonoBehaviour
{
    [SerializeField] private List<Factory> _factories = new List<Factory>();

    private List<GameObject> _createdProducts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Factory factory in _factories)
        {
            IProduct product = factory.GetProduct();

            if (product is Component component) 
            {
                _createdProducts.Add(component.gameObject);
            }
        }
    }
}
