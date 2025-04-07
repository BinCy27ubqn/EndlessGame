using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ObstacleSpawn.Instance.ObtacleSpawn();
    }
}
