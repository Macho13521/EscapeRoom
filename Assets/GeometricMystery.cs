using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometricMystery : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public ZamekController zamekController;

    private string code;

    private void Start()
    {
        code = "";
        GenMystery();
    }

    void GenMystery()
    {
        foreach (var sp in spawnPoints)
        {
            int x = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[x], sp);
            code += x;
        }

        zamekController.SetCode(code);
    }
}
