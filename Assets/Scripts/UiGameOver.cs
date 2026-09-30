using TMPro;
using UnityEngine;

public class UiGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "FINAL SCORE:\n" + scoreKeeper.GetScore().ToString("000000000");
    }
}
