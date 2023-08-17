using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public string GiveMeTag;
    public float RandomChargeAlmount = 15f;
    void Update()
    {
        ChangeMissileDirection();
    }
    void ChangeMissileDirection()
    {
        if (GiveMeTag != null)
        {
            GameObject[] missiles = GameObject.FindGameObjectsWithTag(GiveMeTag);

            foreach (GameObject missile in missiles)
            {
                if (missile != null)
                {
                    Vector3 randomPosition = new Vector3(
                        Random.Range(-RandomChargeAlmount, RandomChargeAlmount),
                        Random.Range(-RandomChargeAlmount, RandomChargeAlmount),
                        Random.Range(-RandomChargeAlmount, RandomChargeAlmount)
                    );

                    missile.transform.position += randomPosition;
                }
            }
        }
        else
        {
            Debug.Log("GiveMeTag is EMPTY");
        }
    }
}
