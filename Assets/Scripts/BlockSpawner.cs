using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] BlockPrefabs;

    private float spawnZ = 0;
    public float blockLenght = 15;

    public int numberOfBlocks;
    

    void Start()
    {
        numberOfBlocks = GameManager.currentLevelIndex;

        for (int i = 0; i < numberOfBlocks; i++)
        {
            SpawnBlock(Random.Range(0, BlockPrefabs.Length - 3));
        }
        
        SpawnBlock(Random.Range(6,9));
    }
    

    void SpawnBlock(int blockIndex)
    {
        Instantiate(BlockPrefabs[blockIndex], transform.forward * spawnZ, transform.rotation);
        spawnZ += blockLenght;
    }
}
