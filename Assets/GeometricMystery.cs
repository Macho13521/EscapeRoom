using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometricMystery : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;

    private void Start()
    {
        GenMystery();
    }

    void GenMystery()
    {
        foreach (var sp in spawnPoints)
        {
            int x = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[x], sp);
        }
    }
}
