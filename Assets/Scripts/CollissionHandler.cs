using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger by" + other.gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided by" + collision.gameObject.name);
    }
}
