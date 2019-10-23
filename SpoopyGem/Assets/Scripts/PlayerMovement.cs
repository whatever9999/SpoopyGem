using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float cantMoveInterval;

    [HideInInspector]
    public bool canMove = true;

    private Rigidbody2D RB;
    private PlayerState PS;

    private float currentCantMoveInterval = 0;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        PS = GetComponent<PlayerState>();
    }

    private void Update()
    {
        if(canMove)
        {
            RB.velocity = new Vector2((Input.GetAxisRaw("P" + PS.playerNumber + "Horizontal") * speed), Input.GetAxisRaw("P" + PS.playerNumber + "Vertical") * speed);
        } else
        {
            RB.velocity = new Vector2(0, 0);
            currentCantMoveInterval += Time.deltaTime;
            
            if(currentCantMoveInterval > cantMoveInterval)
            {
                canMove = true;
                currentCantMoveInterval = 0;
            }
        }
    }
}
