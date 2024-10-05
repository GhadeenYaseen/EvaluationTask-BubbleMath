using System.Collections.Generic;
using UnityEngine;

public class FactoriesManager : MonoBehaviour
{
    [HideInInspector] public static FactoriesManager factoriesManagerInstance;
    [SerializeField] private List<Factory> _factories = new List<Factory>();

    private List<GameObject> _createdProducts = new List<GameObject>();

    private void Awake() 
    {
        factoriesManagerInstance = this;
    }
    
    void Start()
    {
        FireFactories();
    }

    public void FireFactories()
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
