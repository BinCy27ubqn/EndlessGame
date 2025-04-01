using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnPooling : MonoBehaviour
{
    public Transform player;
    public GameObject roadPrefab;
    public float roadLength;

    private List<GameObject> roadListPooling = new List<GameObject>();
  
    private float SpawnDistance = 0;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            RoadSpawn();
        }
    }

    void Update()
    {
        if (roadListPooling.Last().transform.position.z - player.position.z < 23.15f)
        {
            RecycleRoad();
        }
    }

    public void RoadSpawn()
    {
        GameObject roadSpawn = Instantiate(roadPrefab);
        roadSpawn.transform.position = new Vector3(0, 0, SpawnDistance);
        roadListPooling.Add(roadSpawn);
        SpawnDistance += roadLength;
    }

    public void RecycleRoad()
    {
        GameObject firstRoad = roadListPooling.First();
        firstRoad.transform.position = new Vector3(0, 0, SpawnDistance);
        SpawnDistance += roadLength;

        roadListPooling.RemoveAt(0);
        roadListPooling.Add(firstRoad);
    }
}
