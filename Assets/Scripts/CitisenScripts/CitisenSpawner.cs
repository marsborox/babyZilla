using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CitisenSpawner : MonoBehaviour
{
    public float citisenSpawningTime = 0.2f;
    bool spawningInProgress;

    public Citisen citisenPrefab;
    public Citisen_SO citisenSO;
    //public MyGlobalEventHandler myGlobalEventHandler;
    Vector2 _spawnPosition;
    public List<Sprite> citisenSprites;
    public Texture2D mapSprite;
    public Tilemap cityTiles;
    private void Update()
    {
        if (!spawningInProgress)
        { 
            StartCoroutine(SpawnCitisens());
        }
    }

    IEnumerator SpawnCitisens()
    {
        spawningInProgress = true;
        //Debug.Log("targetSpawner.WaitingForSpawn");
        yield return new WaitForSeconds(citisenSpawningTime);
        //Debug.Log("targetSpawner.DoingSpawn");
        //spawnedCitisen.myGlobalEventHandler = myGlobalEventHandler;
        //spawnedCitisen.SubscribeToEvents();
        //SetCitisenProperties(spawnedCitisen,citisenSO);
        
        
        Citisen spawnedCitisen = Instantiate(citisenPrefab, ReturnSpawnPoint(), transform.rotation);
        spawnedCitisen.citisenSprite.sprite=GiveMeRandomSprite();
        //citisenPrefab.transform.position = spawnPosition;
        spawningInProgress = false;
    }
    void SetCitisenProperties(Citisen citisen, Citisen_SO citisenSO)
    {
        if (citisenSO == null)
            return;
        citisen.health = citisenSO.health;
        citisen.citisenSprite.sprite = citisenSO.citisenSprite;
        citisen.movementSpeed = citisenSO.movementSpeed;

    }
    Sprite GiveMeRandomSprite()
    { 
        int index = Random.Range(0,citisenSprites.Count);
        return citisenSprites[index];
    }
    public Vector3 ReturnSpawnPoint()
    {
        Vector3 spawnPoint;
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-5f, 5f);

        while (randomX <= -3.8 && randomX >= 6.2 && randomY <= 1.2 && randomY >= -1.2 ||
            randomX <= 6.2 && randomX >= 3.85 && randomY <= 3.2 && randomY >= 0.8)
        {
            randomX = Random.Range(-5f, 5f);
            randomY = Random.Range(-5f, 5f);
        }

        spawnPoint = new Vector2(randomX, randomY);

        return spawnPoint;
    }
}
