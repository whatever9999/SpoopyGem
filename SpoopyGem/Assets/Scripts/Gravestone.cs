using UnityEngine;

public class Gravestone : MonoBehaviour
{
    public Spawnable[] spawnables;
    public Transform whereToSpawn;
    public float intervalSinceDug;

    private SpriteRenderer SR;

    private float currentIntervalSinceDug;
    private bool dug = false;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(dug)
        {
            currentIntervalSinceDug += Time.deltaTime;

            if(currentIntervalSinceDug > intervalSinceDug)
            {
                dug = false;
                SR.color = Color.yellow;
                currentIntervalSinceDug = 0;
            }
        }
    }

    public void SpawnItem()
    {
        if (!dug)
        {
            dug = true;
            SR.color = Color.black;

            GameObject spawnItem = GetSpawnedItem();

            if (spawnItem != null)
            {
                Instantiate(spawnItem, whereToSpawn.position, whereToSpawn.rotation);
            }
            else
            {
                //Something to indicate no spawn
            }
        }
    }

    private GameObject GetSpawnedItem()
    {
        double total = 0;
        double amount = Random.Range(0, 100);

        for (int i = 0; i < spawnables.Length; i++)
        {
            total += spawnables[i].percentageChance;

            if (amount <= total)
            {
                return spawnables[i].prefab;
            }
        }
        return null;
    }
}

[System.Serializable]
public class Spawnable
{
    public GameObject prefab;
    public float percentageChance;
}