using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public static ScoreManager scoreManagerInstance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreAddedAmount;
    private int _scoreCount;

    private void Awake() 
    {
        scoreManagerInstance = this;
    }

    void Start()
    {
        scoreText.text = " ";
    }

    public void UpdateScore()
    {
        Debug.Log("update score");
        _scoreCount += scoreAddedAmount;
        scoreText.text = _scoreCount.ToString();
    }
}
