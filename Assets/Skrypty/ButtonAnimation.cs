using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private bool isAnimating = false;
    [SerializeField]
    private float offsetOfAnimation;

    private float startPos, endPos;
    private float startTime;
    [SerializeField]
    private float animationDuration = 1.0f;

    void Start()
    {
        startPos = gameObject.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating)
        {
            
            Animating();

        }
    }

    void Animating()
    {

        float time = Time.time - startTime;

        float finalTime = time / animationDuration;


        if (finalTime < 1.0f)
        {
            float xPos = Mathf.Lerp(startPos, endPos, finalTime);
            Vector3 Pos = new Vector3( xPos,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
            gameObject.transform.localPosition = Pos;
        }
        else if(finalTime < 2.0f)
        {
            float xPos = Mathf.Lerp(endPos, startPos, finalTime-1.0f);
            Vector3 Pos = new Vector3(xPos,
                gameObject.transform.localPosition.y,
                gameObject.transform.localPosition.z);
            gameObject.transform.localPosition = Pos;
        }
        else
        {
            isAnimating = false;
        }
        
    }

    public void StartAnimation()
    {
        isAnimating = true;
        startTime = Time.time;
        endPos = startPos - offsetOfAnimation;
    }
}
