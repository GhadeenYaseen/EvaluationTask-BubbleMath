using UnityEngine;
using UnityEngine.Pool;

public class RandomBubblesFactory : Factory
{
    [HideInInspector] public int randomAnswer;

    [SerializeField] private GameObject _currentBubbleProduct;
    [SerializeField] private GameObject parentCanvas;
    [SerializeField] private int _bubblesSpawnAmount = 5;

    private ObjectPool<GameObject> _randomBubblesPool;

    private void Start() 
    {
        //pool stuff
        _randomBubblesPool = new ObjectPool<GameObject>
            (
                () => {return Instantiate(_currentBubbleProduct);},
                GameObject => {GameObject.SetActive(true);},
                GameObject => {GameObject.SetActive(false);},
                GameObject => {Destroy(GameObject);},
                false,
                5, 7
            );
    }

    public override IProduct GetProduct(Transform position)
    {
        // for(int i = 0 ; i<_bubblesSpawnAmount ; ++i)
        // {
            randomAnswer = Mathf.FloorToInt(Random.Range(-20f, 20f));
            GameObject bubbleInstance = _randomBubblesPool.Get();

            bubbleInstance.transform.parent = parentCanvas.transform;
            bubbleInstance.transform.position = position.position + Random.insideUnitSphere * 10;

            IProduct newProduct = bubbleInstance.GetComponent<IProduct>();
            //send random num
            newProduct.GetNumbers(randomAnswer);

            newProduct.DisplayProduct();
            return newProduct;
        //}
    }
}
