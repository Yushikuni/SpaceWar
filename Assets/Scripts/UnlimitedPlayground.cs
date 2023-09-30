using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedPlayground : MonoBehaviour
{
    private bool movingUpwards = true;
    private bool movingRightwards = true;
    public float moveHorizontal;
    public float moveVertical;
    Vector3 upperBoundary;
    Vector3 lowerBoundary;
    Vector3 leftBoundary;
    Vector3 rightBoundary;

    protected PlayerControler controler;

    void Start()
    {
        Screen.SetResolution(800, 600, false);
        controler = GetComponent<PlayerControler>();
    }

    private void Update()
    {
        if (controler != null) 
        {
            LimitedMovement();
        }
    }


    public void UnlimitedPlayerground()
    {
        upperBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        lowerBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0, 0));
        leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2f, 0));
        rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2f, 0));
    }


    void LimitedMovement()
    {
        Vector3 newPosition = transform.position;

        if (moveVertical > 0)
        {
            movingUpwards = true;
        }
        else if (moveVertical < 0)
        {
            movingUpwards = false;
        }

        if (moveHorizontal > 0)
        {
            movingRightwards = true;
        }
        else if (moveHorizontal < 0)
        {
            movingRightwards = false;
        }

        // P�ejmenov�no: transform.Translate(newPosition); na transform.position = newPosition;
        transform.position = newPosition;

        // Pokud dos�hneme horn�ho okraje a pohybujeme se nahoru, nastav�me pozici na doln� okraj
        if (transform.position.y >= upperBoundary.y && movingUpwards)
        {
            transform.position = new Vector3(transform.position.x, lowerBoundary.y, transform.position.z);
        }
        // Pokud dos�hneme doln�ho okraje a pohybujeme se dol�, nastav�me pozici na horn� okraj
        else if (transform.position.y <= lowerBoundary.y && !movingUpwards)
        {
            transform.position = new Vector3(transform.position.x, upperBoundary.y, transform.position.z);
        }
        // Pokud dos�hneme prav�ho okraje a pohybujeme se doprava, nastav�me pozici na lev� okraj
        else if (transform.position.x >= rightBoundary.x && movingRightwards)
        {
            transform.position = new Vector3(leftBoundary.x, transform.position.y, transform.position.z);
        }
        // Pokud dos�hneme lev�ho okraje a pohybujeme se doleva, nastav�me pozici na prav� okraj
        else if (transform.position.x <= leftBoundary.x && !movingRightwards)
        {
            transform.position = new Vector3(rightBoundary.x, transform.position.y, transform.position.z);
        }
    }
}
