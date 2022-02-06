using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float TimeToDestroy =3f;
    void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
