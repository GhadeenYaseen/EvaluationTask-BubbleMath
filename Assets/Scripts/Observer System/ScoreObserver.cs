using UnityEngine;

public class ScoreObserver : MonoBehaviour
{
    [SerializeField] GameObject middleManToObserve;


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
        //call obj pool to disable objects
        Debug.Log("observer notified");
        ValidateAnswer(); 
    }

    private void ValidateAnswer()
    {
        Debug.Log("validate answer func in observer");

        if(ScoreMiddleMan.middleManInstance._clickedAnswer == ScoreMiddleMan.middleManInstance._correctAnswer)
        {
            Debug.Log("ayy correct answer");
            ScoreManager.scoreManagerInstance.UpdateScore();
        }
        else
        {
            Debug.Log("naur incorrect answer");
        }
    }
}
