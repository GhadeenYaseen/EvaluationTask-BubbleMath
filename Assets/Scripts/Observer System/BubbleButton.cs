using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleButton : MonoBehaviour
{
    [HideInInspector] public static BubbleButton bubbleButtonInstance { get; private set;}
    private int _clickedBubble, _correctAnswer;
    private Collider2D _collider;

    public event Action BubbleClicked;

    private void Awake() 
    {
        bubbleButtonInstance = this;
    }

    private void Start() 
    {
        _collider = GetComponent<Collider2D>();
        Debug.Log("start");
    }

    public void NotifyObservers()
    {
        Debug.Log("in bubble notify func");
        BubbleClicked?.Invoke();
    }

    private void Update() 
    {
        CheckCollider();
    }

    private void CheckCollider()
    {
        Debug.Log("check collider");
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked");
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            Debug.Log("ray hit this guy -> " + hit.collider.gameObject.name);
            if(hit.collider == this._collider)
            {
                Debug.Log("mouse cast hit bubble");
                NotifyObservers();
            }
        }
    }

    public void  GetCorrectAnswer (int correctAnswer)
    {
        _correctAnswer = correctAnswer;
    }
}
