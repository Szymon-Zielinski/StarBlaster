using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    static ScoreKeeper scoreKeeper;

    void Awake()
    {
        ScoreSingleton();
    }

    void ScoreSingleton()
    {
        if (scoreKeeper != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeper = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int scoreToAdd)
    {
        score += scoreToAdd;
        score = Mathf.Clamp(score,0,int.MaxValue);
        print(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
    
}
