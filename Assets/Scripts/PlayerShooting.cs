using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject nukePrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public Vector3 nukeOffset = new Vector3(0,0.5f, 0);

    public float fireTimer = 0.5f;
    float cooldownTimer = 0f;
    float nukeCooldownTimer = 500f;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        nukeCooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("kabóóm!");
            cooldownTimer = fireTimer;

            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
       
        if(Input.GetButton("Fire2") && nukeCooldownTimer <= 0) 
        {
            Debug.Log("Nuke release");
            nukeCooldownTimer = fireTimer;

            Instantiate(nukePrefab, transform.position + (transform.rotation * nukeOffset), transform.rotation);
        }
    }
}
