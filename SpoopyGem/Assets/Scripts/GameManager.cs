using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private EndUIManager EndUIM;

    private int P1Score = 0;
    private int P2Score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)MenuUIManager.Scenes.MENU);
        }
    }

    public void UpdateScore(int playerNumber, int newScore)
    {
        if(playerNumber == 1)
        {
            P1Score = newScore;
        } else
        {
            P2Score = newScore;
        }
    }

    public void GoToEndScene()
    {
        AsyncOperation AO = SceneManager.LoadSceneAsync((int)MenuUIManager.Scenes.END);

        StartCoroutine(WaitForSceneLoad(AO));
    }

    IEnumerator WaitForSceneLoad(AsyncOperation AO)
    {
        yield return new WaitUntil(() => AO.isDone == true);

        EndUIM = EndUIManager.instance;
        EndUIM.UpdateScreen(P1Score, P2Score);
    }
}
