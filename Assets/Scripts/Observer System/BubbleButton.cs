using UnityEngine;

public class BubbleButton : MonoBehaviour
{
    [HideInInspector] public static BubbleButton bubbleButtonInstance { get; private set;}
    private int _clickedBubble, _correctAnswer;
    private Collider2D _collider;


    private void Awake() 
    {
        bubbleButtonInstance = this;
    }

    private void Start() 
    {
        _collider = GetComponent<Collider2D>();
        Debug.Log("start");
    }

    private void Update() 
    {
        CheckCollider();
    }

    private void CheckCollider()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            Debug.Log("ray hit this guy -> " + hit.collider.gameObject.name);
            if(hit.collider == this._collider)
            {
                Debug.Log("mouse cast hit bubble");
                ScoreMiddleMan.middleManInstance.NotifyObservers(this);
            }
        }
    }

    public void  GetCorrectAnswer (int correctAnswer)
    {
        _correctAnswer = correctAnswer;
    }
}
