using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private SFXManager SFXM;

    public Text timer;
    public PlayerValueText[] playerScoreTexts;
    public PlayerValueText[] playerInventoryTexts;

    public float startTimeSeconds;

    private float currentTimeSeconds;
    private bool timerBeepStarted = false;

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
        SFXM = SFXManager.instance;
        currentTimeSeconds = startTimeSeconds;
    }

    private void Update()
    {
        currentTimeSeconds -= Time.deltaTime;
        int minutes = (int)(currentTimeSeconds / 60);
        int seconds = (int)(currentTimeSeconds % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(!timerBeepStarted)
        {
            if (currentTimeSeconds <= 5)
            {
                StartCoroutine(TimerBeep());
                timerBeepStarted = true;
            }
        }
        

        if (currentTimeSeconds <= 0)
        {
            GameManager.instance.GoToEndScene();
        }
    }

    public void UpdateScore(int newScore, int playerNumber)
    {
        foreach(PlayerValueText p in playerScoreTexts)
        {
            if(p.playerNumber == playerNumber)
            {
                p.text.text = "Score: " + newScore;
            }
        }
    }

    public void UpdateInventory(int newInventory, int playerNumber)
    {
        foreach (PlayerValueText p in playerInventoryTexts)
        {
            if (p.playerNumber == playerNumber)
            {
                p.text.text = "Inventory: " + newInventory;
            }
        }
    }

    IEnumerator TimerBeep()
    {
        SFXM.PlayEffect(SoundEffectNames.TIMERBEEP);
        yield return new WaitForSeconds(1);
        timerBeepStarted = false;
    }
}

[System.Serializable]
public class PlayerValueText
{
    public int playerNumber;
    public Text text;
}