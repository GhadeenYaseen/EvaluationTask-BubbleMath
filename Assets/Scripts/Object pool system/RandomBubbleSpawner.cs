using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class RandomBubbleSpawner : MonoBehaviour
{
    [HideInInspector] public static RandomBubbleSpawner bubbleSpawnerInstance {get; private set;}

    [SerializeField] private RandomBubble _randomBubblePrefab;
    [SerializeField] private int _spawnAmount = 2;
    private int answer;

    private ObjectPool<RandomBubble> _randomBubblesPool;

    private void Awake() {
        bubbleSpawnerInstance = this;
    }
    
    // object pool set up
    void Start()
    {
        _randomBubblesPool = new ObjectPool<RandomBubble>
                (
                    () => 
                        {
                            return Instantiate(_randomBubblePrefab, RandomSpawnPosition(), Quaternion.identity);
                        },
                    randomBubble => 
                        {
                            //set text here
                            randomBubble.gameObject.GetComponentInChildren<TextMeshPro>().text = 
                                GenerateRandomAnswer().ToString();
                            randomBubble.gameObject.SetActive(true);
                        },
                    randomBubble => 
                        {
                            randomBubble.gameObject.SetActive(false); 
                            randomBubble.gameObject.transform.position = RandomSpawnPosition();
                        },
                    randomBubble => 
                        {
                            Destroy(randomBubble.gameObject);
                        },
                    false,
                    5, 7
                );

        InvokeRepeating(nameof(SpawnBubbles), 0.2f, 1f);
    }

    private void SpawnBubbles()
    {
        for (int i = 0 ; i < _spawnAmount ; ++i)
        {
            var bubble = _randomBubblesPool.Get();
            bubble.Init(KillBubble);
        }
    }

    private int GenerateRandomAnswer()
    {
        answer = Mathf.FloorToInt(UnityEngine.Random.Range(0f, 10f));
        return answer;
    }

    private Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(0.9f,-3.5f);
        float y = -5.97f;

        Vector3 vec3 = new Vector3(x,y,-0.05f);
        
        return vec3;
    }

    public void KillBubble(RandomBubble bubble)
    {
        _randomBubblesPool.Release(bubble);
    }
}
