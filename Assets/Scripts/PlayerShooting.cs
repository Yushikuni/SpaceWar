using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public float fireTimer = 0.1f;
    float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("kabóóm!");
            cooldownTimer = fireTimer;

            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
    }
}
