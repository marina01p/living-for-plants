using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabBtn : MonoBehaviour
{
    public GameObject prefabSpawn;
    public GameObject spawnLocation;
    public float yOffset = 1.0f;

    public void SpawnObj()
    {
        if(prefabSpawn != null && spawnLocation != null)
        {
            Debug.Log("Spawning prefab...");
            Instantiate(prefabSpawn, spawnLocation.transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab or spawn location not assigned.");
        }
    }
}
