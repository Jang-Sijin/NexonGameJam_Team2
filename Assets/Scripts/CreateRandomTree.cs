using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateRandomTree : MonoBehaviour
{
    public GameObject[] treePrefabs;   // 배치할 "나무" 프리팹들 배열
    public GameObject[] bushPrefabs;   // 배치할 "덩쿨" 프리팹들 배열
    public int numberOfTrees = 10;     // 배치할 "나무" 오브젝트의 수

    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            if (randomPosition != Vector3.zero) // 유효한 위치인 경우에만 "나무" 오브젝트 배치
            {
                GameObject randomPrefab = treePrefabs[Random.Range(0, treePrefabs.Length - 1)];
                GameObject treeObject = Instantiate(randomPrefab, randomPosition, Quaternion.identity);
                treeObject.transform.parent = transform;
                
                //GameObject randomPrefab1 = bushPrefabs[Random.Range(0, bushPrefabs.Length - 1)];
                //GameObject bushObject = Instantiate(randomPrefab, randomPosition, Quaternion.identity);
                //bushObject.transform.parent = transform;
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        // 일정한 범위 내에서 랜덤한 위치를 반환
        Bounds bounds = GetComponent<TilemapRenderer>().bounds;
        Vector3 randomPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0f
        );

        return randomPosition;
    }
}