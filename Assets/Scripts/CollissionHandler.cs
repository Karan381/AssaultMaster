using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollissionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem boomVFX;
  
    private void OnTriggerEnter(Collider other)
    {
        
        startcrashseq();
    }

    private void startcrashseq()
    {
        boomVFX.Play();
        //  GetComponent<lasercontrol>().enabled = false;
        // GetComponent<PlayerController>().enabled = false; 
        // GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        Invoke("DestroyPlane", .5f);
        Invoke("ReloadScene", 1f);
    }

    void ReloadScene()
    {
        
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }

   void DestroyPlane()
    {
        gameObject.SetActive(false);
    }
}
