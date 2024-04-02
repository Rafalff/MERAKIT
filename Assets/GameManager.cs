using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;

    public void SpawnItem(GameObject item) {
        Instantiate(item,spawnPosition.position,Quaternion.identity);
    }
}
