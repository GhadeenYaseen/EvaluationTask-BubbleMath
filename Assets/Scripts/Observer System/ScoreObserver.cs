using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] GameObject subjectToObserve;

    private int clickedAnswer=8, correctAnswer=9;

    //add self to observers list of button subject
    private void Awake() 
    {
        if(subjectToObserve != null)
        {
            Debug.Log("subscribed");
            subjectToObserve.GetComponent<BubbleButton>().BubbleClicked += OnNotify;
        }
    }

    //remove self from observers list of button subject
    private void OnDestroy() 
    {
        if(subjectToObserve != null)
        {
            subjectToObserve.GetComponent<BubbleButton>().BubbleClicked -= OnNotify;
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
