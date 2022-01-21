using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMysteryGen : MonoBehaviour
{
    [SerializeField]
    private Vector2 roomSize;

    [SerializeField]
    GameObject[] puzzle;

    [SerializeField]
    int puzzleGenAmount;

    [SerializeField]
    int mysteryCode;

    int[] puzzleTypeAmount;

    Vector2 puzzleSize = new Vector2();

    public ZamekController zamek;

    void Start()
    {
        if (puzzle.Length > 0)
        {
            puzzleTypeAmount = new int[puzzle.Length]; 
            puzzleSize = new Vector2( 
                puzzle[0].GetComponent<MeshRenderer>().bounds.size.x,
                puzzle[0].GetComponent<MeshRenderer>().bounds.size.z);
            Gen();
        }

        if (zamek != null)
            zamek.SetCode(mysteryCode);
    }


    void Gen()
    {
        if ((roomSize.x * roomSize.y) >= (puzzleSize.x*puzzleSize.y)*puzzleGenAmount)
        {
            for (float j=0; j<roomSize.y; j+=puzzleSize.y)
            {
                
                for (float i = 0; i < roomSize.x; i += puzzleSize.x)
                {
                    var random = Random.Range(0, 2);
                    if(random == 0)
                    {
                        var randomPuzzle = Random.Range(0, puzzle.Length);

                        
                        if (puzzleTypeAmount[randomPuzzle] >= 9)
                            continue;

                        puzzleTypeAmount[randomPuzzle]++;


                        var _puzzle = Instantiate(
                            puzzle[randomPuzzle],
                            transform.position + new Vector3(i, -0.93f, j),
                            Quaternion.Euler(-90,0,0));
                        _puzzle.transform.parent = transform;
                        
                    }
                }
            }
        }
        else
        {
            puzzleGenAmount--;
            Gen();
        }

        for (int i = 0; i < puzzleTypeAmount.Length; i++)
        {
            mysteryCode += (int)Mathf.Pow(10, i) * puzzleTypeAmount[i];
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
