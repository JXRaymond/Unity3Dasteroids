using UnityEngine;
using System.Collections;

public class asteroidSpawn : MonoBehaviour {

//#pragma strict

    public Transform[] asteroids;  // Initialized in the inspector
    Transform prefab;
    Vector3 pos;
    GameObject go;

    Vector3 origin = Vector3.zero;

   float minSize = 0.2f;
   float maxSize = 1.5f;

    float minCount = 10f;
    float maxCount = 10f;

    float minDistance = 30.0f;
    float maxDistance = 150.0f;

    public static int num;

    void Start()
    {
        origin = transform.position;
        num = 0;
    }

    void Update()
    {
        if (num <= 0)
        {
            GenerateAsteroids(Random.Range(minCount, maxCount));
            num += 10;
        }
    }
    void GenerateAsteroids(float count)
    {
        for (int i = 0; i < count; i++)
        {
            float size = Random.Range(minSize, maxSize);
            prefab = asteroids[Random.Range(0, asteroids.Length)];

            for (int j = 0; j < 100; j++)
            {
                pos = Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value);
                pos += origin;
                if (!Physics.CheckSphere(pos, size / 2.0f))
                {
                    break;
                }
            }
            Instantiate(prefab, pos, Random.rotation);
            transform.localScale = new Vector3(size, size, size);
        }

    }
    public static void counter()
    {
        num--;
    }
}
