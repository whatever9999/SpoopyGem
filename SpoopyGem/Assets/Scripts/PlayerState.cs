using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerNumber;
    public float invincibleInterval;
    public int scoreFromTreasure;
    public Vector2 startPosition;

    private PlayerMovement PM;
    private UIManager UIM;

    private int score = 0;
    private float currentInvincibleInterval = 0;
    private bool isInvincible;

    private void Start()
    {
        PM = GetComponent<PlayerMovement>();
        UIM = UIManager.instance;

        transform.position = startPosition;
    }

    private void Update()
    {
        if(isInvincible)
        {
            currentInvincibleInterval += Time.deltaTime;
            
            if(currentInvincibleInterval > invincibleInterval)
            {
                isInvincible = false;
                currentInvincibleInterval = 0;
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UIM.UpdateScore(score, playerNumber);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            IncreaseScore(scoreFromTreasure);
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Zombie")
        {
            if(!isInvincible)
            {
                transform.position = startPosition;
                PM.canMove = false;
            }
        } else if (collision.gameObject.tag == "Gravestone")
        {
            isInvincible = true;
        }
    }
}
