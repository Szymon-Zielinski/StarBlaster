using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
  ScoreKeeper scoreKeeper;
  void Awake()
  {
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
  }
  public void LoadGame()
  
  {
    SceneManager.LoadScene("GameScene");
    scoreKeeper.ResetScore();
  }

  

  public void GameOver()
  {
    StartCoroutine(WaitAndLoad("GameOver", 2f));
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
  public void QuitGame()
  {
    Debug.Log("Quit Game");
    Application.Quit();
  }

  IEnumerator WaitAndLoad(string sceneName, float delay)
  {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
  }
}
