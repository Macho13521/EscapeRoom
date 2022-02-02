using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometricMystery : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public ZamekController zamekController;

    private string code;
    private int[] codeInt;


    private void Start()
    {
        code = "";
        codeInt = new int[prefabs.Length];
        GenMystery();
    }

    void GenMystery()
    {
        for (int i=0; i<spawnPoints.Length; i++)
        {
            int x = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[x], spawnPoints[i]);
            if(x == 0)//0 edges
                codeInt[i] = 0;
            else if (x == 1)//3 edges
                codeInt[i] = 3;
            else if (x == 2)
                codeInt[i] = 4;
            else if (x == 3)
                codeInt[i] = 5;
        }

        foreach (int x in codeInt)
        {
            code += x.ToString(); 
        }

        zamekController.SetCode(code);
    }
}
