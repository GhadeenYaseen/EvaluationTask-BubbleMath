using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public static ScoreManager scoreManagerInstance;

    [HideInInspector] public bool isCorrectAnswer;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreAddedAmount;
    private int _scoreCount;

    [SerializeField] private GameObject streakBubble;
    [SerializeField] private TextMeshProUGUI streakText;
    private int _streakCount;

    private void Awake() 
    {
        scoreManagerInstance = this;
    }

    void Start()
    {
        streakBubble.SetActive(false);

        scoreText.text = " ";
        streakText.text = " ";
    }

    public void UpdateUIStats()
    {
        if(isCorrectAnswer)
        {
            Debug.Log("update score");
            _scoreCount += scoreAddedAmount;
            scoreText.text = _scoreCount.ToString();

            streakBubble.SetActive(true);
            _streakCount += 1;
            streakText.text = "+" + _streakCount.ToString();
        }
        else
        {
            Debug.Log("reset streak");
            _streakCount = 0;
            streakText.text = " ";
            streakBubble.SetActive(false);
        }
        
    }
}
