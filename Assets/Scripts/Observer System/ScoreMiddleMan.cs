using System;
using UnityEngine;

/*
    Observer cannot recieve notifications from subject prefabs and clones, so this script acts as its subject and
    will be called by said prefabs (middle man)
*/

public class ScoreMiddleMan : MonoBehaviour
{
    [HideInInspector] public static ScoreMiddleMan middleManInstance {get; private set;}
    
    [HideInInspector] public int _clickedAnswer, _correctAnswer;
    public event Action BubbleClicked;

    private void Awake() 
    {
        middleManInstance = this;
    }

    public void NotifyObservers(BubbleButton bubbleButton)
    {
        Debug.Log("middle man notify func");
        BubbleClicked?.Invoke();
    }

    public void  GetCorrectAnswer (int correctAnswer)
    {
        _correctAnswer = correctAnswer;
    }

    public void  GetClickedAnswer (int clickedAnswer)
    {
        _clickedAnswer = clickedAnswer;
    }
}
