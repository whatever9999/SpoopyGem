using UnityEngine;
using System.Collections;

public class GravestoneManager : MonoBehaviour
{
    public GameObject gravestone;

    public int numberGravestones;
    public Vector2 spawnBottomLeft;
    public Vector2 spawnTopRight;
    public float secondsToCheckReactivate;

    private GameObject[] gravestones;

    private void Start()
    {
        gravestones = new GameObject[numberGravestones];

        for(int i = 0; i < numberGravestones; i++)
        {
            bool gotLocation = false;
            Vector2 gravestoneLocation;
            do
            {
                gravestoneLocation = new Vector2((int)Random.Range(spawnBottomLeft.x, spawnTopRight.x), (int)Random.Range(spawnBottomLeft.y, spawnTopRight.y));
                gotLocation = true;

                for(int j = 0; j < i; j++)
                {
                    if((Vector2)gravestones[j].transform.position == gravestoneLocation)
                    {
                        gotLocation = false;
                        break;
                    }
                }
            } while (!gotLocation);
            
            gravestones[i] = Instantiate(gravestone, gravestoneLocation, Quaternion.identity);
        }

        StartCoroutine(CheckToMakeActive());
    }

    IEnumerator CheckToMakeActive()
    {
        foreach (GameObject g in gravestones)
        {
            if (!g.active)
            {
                int rand = Random.Range(0, 2);

                if(rand == 0)
                {
                    g.active = true;
                }
            }
        }

        yield return new WaitForSeconds(secondsToCheckReactivate);

        StartCoroutine(CheckToMakeActive());
    }
}
