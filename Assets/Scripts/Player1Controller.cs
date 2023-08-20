using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movementSpeed = 5f;
    float rotationSpeed = 5f;
    float moveHorizontal;
    float moveVertical;
    private bool movingUpwards = true;
    private bool movingRightwards = true;
    Vector3 upperBoundary;
    Vector3 lowerBoundary;
    Vector3 leftBoundary;
    Vector3 rightBoundary;

    protected MissileScript missile;
    protected NukeScript nuke;
    protected RandomWarp RandomWarp;

    Rigidbody2D rigidbodyPlayer1;

    private void Start()
    {
        Screen.SetResolution(800, 600, false);
        rigidbodyPlayer1 = GetComponent<Rigidbody2D>();
        rigidbodyPlayer1.gravityScale = 1;
        SetLimitedMovement();
        missile = GetComponent<MissileScript>();
        nuke = GetComponent<NukeScript>();
        RandomWarp = GetComponent<RandomWarp>();
    }

    void Update()
    {
        Movement();
        Rotation();
        LimitedMovement();
        RandomWarping();
        RocketLauncher();
        NuclearAttack();
    }

    void Movement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime * 5f);
            transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime * 5f);
            //Mathf.Clamp(0f - rotationSpeed * Time.deltaTime, 90f, -90f);
            transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime * 5f);
        }
    }

    void SetLimitedMovement()
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

        // Pøejmenováno: transform.Translate(newPosition); na transform.position = newPosition;
        transform.position = newPosition;

        // Pokud dosáhneme horního okraje a pohybujeme se nahoru, nastavíme pozici na dolní okraj
        if (transform.position.y >= upperBoundary.y && movingUpwards)
        {
            transform.position = new Vector3(transform.position.x, lowerBoundary.y, transform.position.z);
        }
        // Pokud dosáhneme dolního okraje a pohybujeme se dolù, nastavíme pozici na horní okraj
        else if (transform.position.y <= lowerBoundary.y && !movingUpwards)
        {
            transform.position = new Vector3(transform.position.x, upperBoundary.y, transform.position.z);
        }
        // Pokud dosáhneme pravého okraje a pohybujeme se doprava, nastavíme pozici na levý okraj
        else if (transform.position.x >= rightBoundary.x && movingRightwards)
        {
            transform.position = new Vector3(leftBoundary.x, transform.position.y, transform.position.z);
        }
        // Pokud dosáhneme levého okraje a pohybujeme se doleva, nastavíme pozici na pravý okraj
        else if (transform.position.x <= leftBoundary.x && !movingRightwards)
        {
            transform.position = new Vector3(rightBoundary.x, transform.position.y, transform.position.z);
        }
    }

    void RocketLauncher()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("PEW :)");
            missile.SpawnProjectile();
        }
    }

    void NuclearAttack()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Kabooom");
            nuke.SpawnProjectile();
        }
    }

    void RandomWarping()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("Warping....");

            RandomWarp.RandomWarping();
        }
    }
}
