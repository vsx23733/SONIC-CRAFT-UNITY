using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject gameStatsText;
    public GameObject gameScoreText;
    public GameObject gameOverPanel;
    public PlayerHealth health;


    public LevelLoader levelLoader;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        gameStatsText.SetActive(false);
        gameScoreText.SetActive(false);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        gameStatsText.SetActive(true);
        gameScoreText.SetActive(true);
        levelLoader.GenerateLevel();

    }

    public void GameOver(bool win)
    {
        gameOverPanel.SetActive(true);

        if (win)
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Level Complete!";
        else
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over";
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        gameStatsText.SetActive(true);

        GameObject existingSonic = GameObject.FindGameObjectWithTag("Player");
        if (existingSonic != null)
        {
            Destroy(existingSonic);
        }

        levelLoader.GenerateLevel();
    }


    public int getRingCount()
    {
        int numRing = health.ringCount;
        return numRing;
    }

    public float getScore()
    {
        float score = health.finalScore;
        return score;
    }

    public void UpdateRingCount(int count)
    {
        TextMeshProUGUI textComponent = gameStatsText.GetComponent<TextMeshProUGUI>(); 

        if (textComponent != null)
        {
            textComponent.text = "Rings: " + count; 
        }
        else
        {
            Debug.LogError("No Text component found on gameStatsText GameObject!");
        }
    }

    public void UpdateScore(float score)
    {
        TextMeshProUGUI textComponent = gameScoreText.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "Score: " + score;
        }

        else
        {
            Debug.LogError("No Text component found on gameScoreText GameObject!");
        }
    }

}