using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWarp : MonoBehaviour
{

    Vector3 upperBoundary;
    Vector3 lowerBoundary;
    Vector3 leftBoundary;
    Vector3 rightBoundary;

    private void Start()
    {
        upperBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        lowerBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0, 0));
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2f, 0));
        rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2f, 0));
    }

    public void RandomWarping()
    {
        Debug.Log("Warping....");

        float newX = Random.Range(leftBoundary.x, rightBoundary.x);
        float newY = Random.Range(lowerBoundary.y, upperBoundary.y);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
