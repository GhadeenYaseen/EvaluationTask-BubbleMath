using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private float RemainingTime;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
        }
        else if(RemainingTime <= 0)
        {
            RemainingTime = 0;
            DisplayWinPanel();
        }

        int Seconds = Mathf.FloorToInt(RemainingTime % 60);
        timerText.text = "Time: " + Seconds + "s";
    }

    public void DisplayWinPanel()
    {
        Time.timeScale = 0;
        finalScore.text = "Score " + ScoreManager.scoreManagerInstance._scoreCount;
        winPanel.SetActive(true);
    }

    public void PlayRound()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
