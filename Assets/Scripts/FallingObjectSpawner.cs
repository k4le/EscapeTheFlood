using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{

    public int rangeX;
    public int rangeY;
    public GameObject[] ObjectPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
	{
        Instantiate(ObjectPrefabs[Random.Range(0, ObjectPrefabs.Length - 1)], new Vector3(UnityEngine.Random.Range(0, rangeX), 30, 0), transform.rotation);
    }
}
