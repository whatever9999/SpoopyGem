using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerNumber;
    //public float invincibleInterval;
    public int scoreFromTreasure;
    public Vector2 startPosition;
    public int inventoryCapacity;

    private PlayerMovement PM;
    private UIManager UIM;

    private int score = 0;
    private int inventory = 0;
    //private float currentInvincibleInterval = 0;
    //private bool isInvincible;

    private void Start()
    {
        PM = GetComponent<PlayerMovement>();
        UIM = UIManager.instance;

        transform.position = startPosition;
    }

    private void Update()
    {
        //if(isInvincible)
        //{
        //    currentInvincibleInterval += Time.deltaTime;
        //    
        //    if(currentInvincibleInterval > invincibleInterval)
        //    {
        //        isInvincible = false;
        //        currentInvincibleInterval = 0;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            if(inventory < inventoryCapacity)
            {
                inventory += scoreFromTreasure;
                UIM.UpdateInventory(inventory, playerNumber);
                Destroy(collision.gameObject);
            } else
            {
                //Show inventory is full (thought bubble of van and shake inventory text)
            }
        } else if (collision.gameObject.tag == "Zombie")
        {
            //if(!isInvincible)
            {
                inventory = 0;
                UIM.UpdateInventory(inventory, playerNumber);
                transform.position = startPosition;
                PM.canMove = false;
            }
        } else if (collision.gameObject.tag == "Gravestone")
        {
            //isInvincible = true;
        } else if (collision.gameObject.tag == "Van")
        {
            if (collision.gameObject.GetComponent<Van>().playerNumber == playerNumber)
            {
                score += inventory;
                UIM.UpdateScore(score, playerNumber);
                inventory = 0;
                UIM.UpdateInventory(inventory, playerNumber);
            } else
            {
                //Shake their van to show they're at the wrong one
                //Could create a stealing mechanic
            }
            
        }
    }
}
