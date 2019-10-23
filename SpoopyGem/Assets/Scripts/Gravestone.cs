using UnityEngine;

public class Gravestone : MonoBehaviour
{
    public GameObject[] spawnables;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int rand = (int)Random.Range(0, spawnables.Length);

            Instantiate(spawnables[rand], transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}