using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] GameObject middleManToObserve;

    private int clickedAnswer=8, correctAnswer=9;

    //add self to observers list of button subject
    private void Awake() 
    {
        if(middleManToObserve != null)
        {
            Debug.Log("subscribed");
            middleManToObserve.GetComponent<ScoreMiddleMan>().BubbleClicked += OnNotify;
        }
    }

    //remove self from observers list of button subject
    private void OnDestroy() 
    {
        if(middleManToObserve != null)
        {
            middleManToObserve.GetComponent<ScoreMiddleMan>().BubbleClicked -= OnNotify;
        }
    }

    public void OnNotify()
    {
        //validate answer
        //call obj pool to disable objects
        Debug.Log("observer notified");
        ValidateAnswer(); 
    }

    private void ValidateAnswer()
    {
        if(clickedAnswer == correctAnswer)
        {
            Debug.Log("ayy correct answer");
            //call update score and streak
        }
        else
        {
            Debug.Log("naur incorrect answer");
        }
    }
}
