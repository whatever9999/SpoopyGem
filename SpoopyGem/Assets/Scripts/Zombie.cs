using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float speed;
    public int timeAlive;
    public float timeToChangeDirection;

    private Rigidbody2D RB;

    private bool justSpawned = true;
    private float currentTimeSinceChangedDirection = 0;
    private Vector2 currentSpeed;

    private enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        currentSpeed = GetDirection();
        justSpawned = false;

        StartCoroutine(Die());
    }

    private void Update()
    {
        currentTimeSinceChangedDirection += Time.deltaTime;

        if (currentTimeSinceChangedDirection > timeToChangeDirection)
        {
            currentSpeed = GetDirection();
            currentTimeSinceChangedDirection = 0;
        }

        RB.velocity = currentSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        currentSpeed = GetDirection();
    }

    private Vector2 GetDirection()
    {
        int direction = Random.Range(0, 4);

        Vector2 newDirection = new Vector2(0, 0);

        switch (direction)
        {
            case (int)Direction.LEFT:
                newDirection.x = -speed;
                break;
            case (int)Direction.RIGHT:
                newDirection.x = speed;
                break;
            case (int)Direction.UP:
                if(!justSpawned)
                {
                    newDirection.y = speed;
                } else
                {
                    newDirection.x = -speed;
                }
                break;
            case (int)Direction.DOWN:
                if (!justSpawned)
                {
                    newDirection.y = -speed;
                }
                else
                {
                    newDirection.x = speed;
                }
                break;
        }

        return newDirection;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(timeAlive);

        Destroy(gameObject);
    }
}
