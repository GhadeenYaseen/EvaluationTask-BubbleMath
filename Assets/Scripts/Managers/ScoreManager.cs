using TMPro;
using UnityEngine;
using EZCameraShake;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public static ScoreManager scoreManagerInstance;

    [HideInInspector] public bool isCorrectAnswer;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int scoreAddedAmount;
    [HideInInspector] public int _scoreCount;

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
            SoundManager.PlaySound(SoundType.CorrectAnswer);

            _scoreCount += scoreAddedAmount;
            scoreText.text = _scoreCount.ToString();
            scoreText.gameObject.GetComponentInParent<SquashAndStretch>().PlaySquashAndStretch();
            

            streakBubble.SetActive(true);
            streakBubble.GetComponent<SquashAndStretch>().PlaySquashAndStretch();
            _streakCount += 1;
            streakText.text = "+" + _streakCount.ToString();
        }
        else
        {
            SoundManager.PlaySound(SoundType.WrongAnswer);
            CameraShaker.Instance.ShakeOnce(3f, 3f, 0.2f, 0.2f);
            
            _streakCount = 0;
            streakText.text = " ";
            streakBubble.SetActive(false);
        }
    }
}
