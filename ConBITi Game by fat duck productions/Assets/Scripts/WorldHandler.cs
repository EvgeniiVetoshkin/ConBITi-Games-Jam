using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    private static WorldHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("2 handler");
            Destroy(gameObject);
        }
    }

    public void SpawnObject(GameObject objectToSpawn,Transform positionToSpawn)
    {
        Instantiate(objectToSpawn, positionToSpawn);
    }
}
