using System.Collections.Generic;
using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] Factory factory;
    public RectTransform productPos;
    private List<GameObject> _CreatedProducts = new List<GameObject>();

    public void OnClickGenerate()
    {
        Debug.Log("button clicked");
        IProduct product= factory.GetProduct(productPos);

        if(product is Component component)
        {
            _CreatedProducts.Add(component.gameObject);
        }
    }

    private void OnDestroy() 
    {
        foreach (GameObject product in _CreatedProducts)
        {
            //disable in object pool
            Destroy(product);
        }
        _CreatedProducts.Clear();
    }
}
