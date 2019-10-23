using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    public float speed;
    public int timeAlive;

    private Rigidbody2D RB;

    private enum X
    {
        LEFT,
        RIGHT
    }
    private enum Y
    {
        UP,
        DOWN
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        RB.velocity = GetNewDirection();

        StartCoroutine(Die());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newVelocity = RB.velocity;

        do
        {
            newVelocity = GetNewDirection();
        } while (newVelocity == RB.velocity);

        RB.velocity = newVelocity;
    }

    private Vector2 GetNewDirection()
    {
        int x = Random.Range(0, 2);
        int y = Random.Range(0, 2);

        Vector2 newDirection = new Vector2(0, 0);

        switch (x)
        {
            case (int)X.LEFT:
                newDirection.x = -speed;
                break;
            case (int)X.RIGHT:
                newDirection.x = speed;
                break;
            default:
                break;
        }

        switch (y)
        {
            case (int)Y.UP:
                newDirection.y = speed;
                break;
            case (int)Y.DOWN:
                newDirection.y = -speed;
                break;
            default:
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
