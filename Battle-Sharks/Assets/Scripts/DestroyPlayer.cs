using UnityEngine;
using System.Collections.Generic;


public class PlayerCollision : MonoBehaviour
{

    public int destroyCount = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyPlayerChildren();
        }
    }

    private void DestroyPlayerChildren()
    {
        Queue<GameObject> playerChildrenQueue = new Queue<GameObject>(GameObject.FindGameObjectsWithTag("PlayerChildren"));
        for (int i = 0; i < destroyCount && playerChildrenQueue.Count > 0; i++)
        {
            Destroy(playerChildrenQueue.Dequeue());
        }
    }
}
