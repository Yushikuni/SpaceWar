using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //TODO: Fix infinity playerground

    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;


    protected UnlimitedPlayground unlimitedPlayground;

    void Start()
    {
        unlimitedPlayground.UnlimitedPlayerground();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
    }


    void Movement()
    {
        unlimitedPlayground.moveHorizontal = Input.GetAxis("Horizontal");
        unlimitedPlayground.moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(unlimitedPlayground.moveHorizontal, unlimitedPlayground.moveVertical, 0) * movementSpeed * Time.deltaTime;
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
}
