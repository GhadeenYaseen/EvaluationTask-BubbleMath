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
        Debug.Log("observer notified");
        ValidateAnswer(); 
    }

    private void ValidateAnswer()
    {
        if(ScoreMiddleMan.middleManInstance._clickedAnswer == ScoreMiddleMan.middleManInstance._correctAnswer)
        {
            ScoreManager.scoreManagerInstance.isCorrectAnswer = true;
            FactoriesManager.factoriesManagerInstance.FireFactories();
            
        }
        else
        {
            ScoreManager.scoreManagerInstance.isCorrectAnswer = false;
        }
        
        ScoreManager.scoreManagerInstance.UpdateUIStats();
    }
}
