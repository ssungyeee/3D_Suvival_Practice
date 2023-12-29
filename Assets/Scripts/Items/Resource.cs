using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Resource : MonoBehaviour
{
    public GameObject prefab;
    public int quantityPerHit = 1;
    public int capacity;

    public void Gather(Vector3 position, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
            Instantiate(prefab, position + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }

        if (capacity <= 0)
        {
            Destroy(gameObject);
        }            
    }
}