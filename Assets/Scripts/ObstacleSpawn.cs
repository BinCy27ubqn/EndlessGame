using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public static ObstacleSpawn Instance;

    public List<GameObject>obstaclePrefabs;
    public List<GameObject>obstaclePool;
    public GameObject player;

    void Start()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        Instantiate(obstaclePrefabs[0]);

        obstaclePool.Add(obstaclePrefabs[0]);

        for (int i = 1; i < obstaclePrefabs.Count; i++)
        {
            GameObject pref = Instantiate(obstaclePrefabs[i]);
            pref.SetActive(false);
            obstaclePool.Add(pref);
        }
    }

    public void ObtacleSpawn()
    {

        List<GameObject> pref = new List<GameObject>();

        for (int i = 0; i < obstaclePool.Count; i++)
        {
            
            pref.Add(obstaclePool[i]);
        }

        int ran = Random.Range(0, pref.Count - 1);

        if (!pref[ran].activeInHierarchy)
        {
            pref[ran].SetActive(true);
        }

        pref[ran].transform.position = new Vector3(pref[ran].transform.position.x, pref[ran].transform.position.y, player.transform.position.z + 90f);
    }
}
