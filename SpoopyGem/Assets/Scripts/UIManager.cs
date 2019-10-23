using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text timer;
    public PlayerScoreText[] playerScoreTexts;

    public float startTimeSeconds;

    private float currentTimeSeconds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        currentTimeSeconds = startTimeSeconds;
    }

    private void Update()
    {
        currentTimeSeconds -= Time.deltaTime;
        int minutes = (int)(currentTimeSeconds / 60);
        int seconds = (int)(currentTimeSeconds % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTimeSeconds <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void UpdateScore(int newScore, int playerNumber)
    {
        foreach(PlayerScoreText p in playerScoreTexts)
        {
            if(p.playerNumber == playerNumber)
            {
                p.text.text = "P" + playerNumber + ": " + newScore;
            }
        }
    }
}

[System.Serializable]
public class PlayerScoreText
{
    public int playerNumber;
    public Text text;
}