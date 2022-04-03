using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;

    public int distanceBetweenPlatforms = 50;

    public int MaxCountOfExistingPlatforms = 3;

    List<GameObject> generatedPlatforms;

    Vector2 cameraStartPosition;

    int totalCountOfGeneratedPlatforms;

    void GeneratePlatform(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            int platformID = totalCountOfGeneratedPlatforms;

            if (platformID > PlatformPrefabs.Length - 1 )
            {
                platformID = PlatformPrefabs.Length - 1;
            }

            //GameObject newPlatform =;
            GameObject newPlatform = Instantiate(PlatformPrefabs[platformID], new Vector2(0, cameraStartPosition.y + distanceBetweenPlatforms + totalCountOfGeneratedPlatforms * distanceBetweenPlatforms), transform.rotation);
            generatedPlatforms.Add(newPlatform);
            totalCountOfGeneratedPlatforms++;

            if (MaxCountOfExistingPlatforms < generatedPlatforms.Count)
            {
                Destroy(generatedPlatforms[0]);
                generatedPlatforms.RemoveAt(0);

                //Cleanup old blocks
                CleanupObjects();
            }
        }
    }

    void CleanupObjects()
    {
        int idOfLowestPlatform = totalCountOfGeneratedPlatforms - MaxCountOfExistingPlatforms;
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            if ("FallingObject" == gameObject.tag)
            {
                if (gameObject.transform.position.y < cameraStartPosition.y + idOfLowestPlatform * distanceBetweenPlatforms - distanceBetweenPlatforms)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        generatedPlatforms = new List<GameObject>();
        cameraStartPosition = Camera.main.transform.position;
        totalCountOfGeneratedPlatforms = 0;
        GeneratePlatform(MaxCountOfExistingPlatforms);
    }

    // Update is called once per frame
    void Update()
    {
        //Generate new platform
        int idOfMiddlestPlatform = totalCountOfGeneratedPlatforms - MaxCountOfExistingPlatforms / 2;
        if (Camera.main.transform.position.y > cameraStartPosition.y + distanceBetweenPlatforms + idOfMiddlestPlatform * distanceBetweenPlatforms)
        {
            GeneratePlatform();
        }

    }
}
