using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected PlayerMovement PlayerMovement;
    protected MissileScript missile;
    protected NukeScript nuke;
    protected RandomWarp RandomWarp;

    Rigidbody2D rigidbodyPlayer1;

    private void Start()
    {
        Screen.SetResolution(800, 600, false);
        rigidbodyPlayer1 = GetComponent<Rigidbody2D>();
        rigidbodyPlayer1.gravityScale = 1;
        missile = GetComponent<MissileScript>();
        nuke = GetComponent<NukeScript>();
        RandomWarp = GetComponent<RandomWarp>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        RandomWarping();
        RocketLauncher();
        NuclearAttack();
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
