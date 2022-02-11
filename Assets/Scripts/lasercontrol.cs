using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercontrol : MonoBehaviour
{
    [Header("Laser settings")]
    [SerializeField] GameObject[] lasers; // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if (Input.GetMouseButton(0))
        {
            SetLasersActive();
        }
        else
        {
            SetLasersDeactive();
        }

    }

    void SetLasersActive()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = true;
        }
    }

    void SetLasersDeactive()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = false;
        }

    }

    
}
