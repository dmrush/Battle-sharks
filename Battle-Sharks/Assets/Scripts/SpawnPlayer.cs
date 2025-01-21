using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject objectToSpawn; // The GameObject to spawn
    public int spawnCount = 5; // Number of GameObjects to spawn
    public Transform spawnPoint; // The point where GameObjects will be spawned

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision has occured with player");
            
            for (int i = 0; i < spawnCount; i++)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}

