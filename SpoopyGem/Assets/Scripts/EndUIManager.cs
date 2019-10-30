using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIManager : MonoBehaviour
{
    public static EndUIManager instance;

    public Text P1ScoreText;
    public Text P2ScoreText;
    public Text WinnerAnnouncementText;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene((int)MenuUIManager.Scenes.GAME);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void UpdateScreen(int P1Score, int P2Score)
    {
        if(P1Score > P2Score)
        {
            WinnerAnnouncementText.text = "Player One Wins...";
        } else if (P1Score < P2Score)
        {
            WinnerAnnouncementText.text = "Player Two Wins...";
        } else
        {
            WinnerAnnouncementText.text = "Draw...";
        }

        P1ScoreText.text = "Player One Score: " + P1Score;
        P2ScoreText.text = "Player Two Score: " + P2Score;
    }
}
