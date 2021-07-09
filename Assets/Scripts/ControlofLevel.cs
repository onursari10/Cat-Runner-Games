using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlofLevel : MonoBehaviour
{

    public GameObject[] prefabs;
    private Transform Player;

    public float Blackarea = 200.0f;
    private List<GameObject> activePrefabs;
    public int prefabsOnScreen = 4;
    public int lastPrefab = 0;
    public float spawnPrefab = -100.0f;
    public float prefabLength = 99.0f;



    private void Start()
    {
        activePrefabs = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < prefabsOnScreen; i++)
        {
            if (i < 4)
            {
                Spawn(0);
            }
            else
            {
                Spawn();
            }
        }
    }

    private void Update()
    {
        if (Player.position.z - Blackarea > (spawnPrefab - prefabsOnScreen * prefabLength))
        {
            Spawn();
            DeletePrefab();
        }
    }

    private void Spawn(int prefabIndex = -1)
    {

        GameObject myPrefab;
        if (prefabIndex == -1)
        {
            myPrefab = Instantiate(prefabs[RandomPrefabs()] as GameObject);
        }
        else
        {
            myPrefab = Instantiate(prefabs[prefabIndex] as GameObject);
        }

        myPrefab.transform.SetParent(transform);
        myPrefab.transform.position = Vector3.forward * spawnPrefab;
        spawnPrefab += prefabLength;
        activePrefabs.Add(myPrefab);
    }

    private void DeletePrefab()
    {
        Destroy(activePrefabs[0]);
        activePrefabs.RemoveAt(0);
    }

    private int RandomPrefabs()
    {
        if (prefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefab;

        while (randomIndex == lastPrefab)
        {
            randomIndex = Random.Range(0, prefabs.Length);
        }

        lastPrefab = randomIndex;
        return randomIndex;
    }
}
