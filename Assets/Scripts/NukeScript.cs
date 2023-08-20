using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    protected Transform ProjectileSpawner;
    //Spawn Nuke bomb with coldown 5 minutes
    public void SpawnProjectile()
    {
        Debug.Log("In function SPAW NUKE…");
        if (ProjectilePrefab != null && ProjectileSpawner != null)
        {
            Debug.Log("Not Null SPAWNING…");
            Instantiate(ProjectilePrefab, ProjectileSpawner.position, ProjectileSpawner.rotation);
        }
    }
}
