
using TMPro;
using UnityEngine;

public class BubbleButton : MonoBehaviour
{
    [HideInInspector] public static BubbleButton bubbleButtonInstance { get; private set;}
    
    private Collider2D _collider;

    [SerializeField] ParticleSystem burstParticles;
    private ParticleSystem _burstParticlesInstance;
    private RandomBubble randomBubble;
    private SquashAndStretch squashAndStretch;

    private void Awake() 
    {
        bubbleButtonInstance = this;

        randomBubble = gameObject.GetComponent<RandomBubble>();
        squashAndStretch = gameObject.GetComponent<SquashAndStretch>();
    }

    private void Start() 
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Update() 
    {
        CheckCollider();
    }

    private void CheckCollider()
    {
        if(Time.timeScale == 0)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if(hit.collider == this._collider)
            {
                Debug.Log("mouse cast hit bubble");
                SoundManager.PlaySound(SoundType.BubbleBurst);
                squashAndStretch.PlaySquashAndStretch();
                
                ScoreMiddleMan.middleManInstance.GetClickedAnswer(int.Parse(gameObject.GetComponentInChildren<TextMeshPro>().text));
                ScoreMiddleMan.middleManInstance.NotifyObservers(this);

                StartBurstParticles();

                if(randomBubble != null)
                {
                    RandomBubbleSpawner.bubbleSpawnerInstance.KillBubble(randomBubble);
                }
                
                CheckCorrectAnswerBeforeKill();
            }
        }
    }

    private void CheckCorrectAnswerBeforeKill()
    {
        if(gameObject.GetComponent<AdditionBubbleProduct>() != null)
        {
            Destroy(gameObject);
        }

        if(gameObject.GetComponent<SubtractionBubbleProduct>() != null)
        {
            Destroy(gameObject);
        }

        if(gameObject.GetComponent<MultiplicationBubblesProduct>() != null)
        {
            Destroy(gameObject);
        }
    }

    private void StartBurstParticles()
    {
        _burstParticlesInstance = Instantiate(burstParticles, transform.position, Quaternion.identity);
    }
}
