using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    protected Transform ProjectileSpawner;
    //Spawn bomb every time
    public void SpawnProjectile()
    {
        Debug.Log("In function SPAW PROJECTILE…");
        if (ProjectilePrefab != null)
        {
            Debug.Log("Not Null SPAWNING…");
            Instantiate(ProjectilePrefab, ProjectileSpawner.position, ProjectileSpawner.rotation);
        }        
    }
}
